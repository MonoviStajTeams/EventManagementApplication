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
using System.Net;
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
                ResetToken = "test",
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

                string subject = "Şifre Sıfırlama Kodu";
                string body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f7fa;
            margin: 0;
            padding: 0;
        }}
        .container {{
            padding: 20px;
            max-width: 600px;
            margin: auto;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }}
        .title {{
            font-size: 24px;
            color: #7E57FF;
            text-align: center;
            margin-bottom: 20px;
        }}
        .content {{
            font-size: 16px;
            color: #333;
        }}
        .activation-code {{
            background-color: #7E57FF;
            color: white;
            padding: 5px 10px;
            border-radius: 5px;
            font-weight: bold;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='title'>Şifre Sıfırlama Aktivasyon Kodu</div>
        <div class='content'>
            Şifre sıfırlama için aşağıdaki aktivasyon kodunu kullanabilirsiniz:<br>
            <span class='activation-code'>{activationCode}</span>
        </div>
    </div>
</body>
</html>";


                using (var client = new SmtpClient())
                {
                    client.Port = 587;
                    client.Host = "mail.bytesynthix.com";
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("test@bytesynthix.com", "142536oA.12");

                    MailMessage mailMessage = new MailMessage("test@bytesynthix.com", "oguzhanagir4@gmail.com", subject, body);

                    mailMessage.IsBodyHtml = true;
                    client.Send(mailMessage);
                }

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


        public bool VerifyActivationCode(string enteredCode, int userId)
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
