using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Core.Constants;
using EventManagementApplication.Core.Utilities.Results;
using EventManagementApplication.Core.Utilities.Security.Hashing;
using EventManagementApplication.Core.Utilities.Security.JWT;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Entities.Dtos;
using PostSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Mail = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                ResetToken ="test",
                ResetTokenExpiration = DateTime.Now.AddDays(2)
                
               
            };
            _userService.Create(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }



        //Reset Password
        public IDataResult<bool> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = _userService.GetByMail(resetPasswordDto.Email);
            
            if (user == null)
            {
                return new ErrorDataResult<bool>("User not found.");
            }

            if (!VerifyResetToken(user, resetPasswordDto.Token))
            {
                return new ErrorDataResult<bool>("Invalid reset token.");
            }

            if (resetPasswordDto.NewPassword != resetPasswordDto.ConfirmPassword)
            {
                return new ErrorDataResult<bool>("Passwords do not match.");
            }

            // If everything is valid, update the user's password
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(resetPasswordDto.NewPassword, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _userService.Update(user);
            return new SuccessDataResult<bool>(true, "Password reset successful.");
        }

        private bool VerifyResetToken(User user, string token)
        {
            // Implement token verification logic here, e.g., check against user's stored reset token.
            // You can use libraries like JWT or Identity for token management.

            // Example (simplified for illustration purposes):
            return user.ResetToken == token && user.ResetTokenExpiration > DateTime.Now;
        }
    
       
        public void SendMailCodeByResetPassword(string mail)
        {
            string activationCode = GenerateActivationCode();

            try
            {

                //Mail Helper methodu olarak düzenlenecek

                SmtpClient smtpClient = new SmtpClient("mail.yipadanismanlik.com", 465);

                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 10000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("test@yipadanismanlik.com", "monovi1234");

                string subject = "Şifre Sıfırlama Kodu";
                string body = "Şifre sıfırlama için aktivasyon kodunuz: " + activationCode;  //Mail body kısmı düzenlenecek

                var mailMessage = new MailMessage("test@yipadanismanlik.com", "test@yipadanismanlik.com", subject,body);
               

                smtpClient.Send(mailMessage);

                var user = _userService.GetByMail(mail);

                user.ResetCode = activationCode;

                _userService.Update(user);

                // Aktivasyon kodu sorulacak
            }
            catch (Exception ex)
            {

                throw new Exception("E-posta gönderirken bir hata oluştu: " + ex.Message);
            }
        }

      
        private string GenerateActivationCode()
        {
            RandomNumberGenerator rng = RNGCryptoServiceProvider.Create();
            byte[] randomBytes = new byte[6];
            rng.GetBytes(randomBytes);

            StringBuilder activationCodeBuilder = new StringBuilder();
            foreach (byte b in randomBytes)
            {
                activationCodeBuilder.Append(b.ToString("X2"));
            }

            return activationCodeBuilder.ToString();
        }

       
        public bool VerifyActivationCode(string enteredCode,int userId)
        {
            var resetCodeUser = _userService.GetById(userId);

            if (enteredCode == resetCodeUser.ResetCode)
            {
            return true;

            }

            return false;
        }
    }
}
