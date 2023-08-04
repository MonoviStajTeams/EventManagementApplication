using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Dtos;
using EventManagementApplication.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace EventManagementApplication.WebUI.Controllers
{
   
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                ViewBag.ErrorMessage = "Email Adresi veya Şifre Yanlış.";
                return View();
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                HttpContext.Session.SetString("Email", userForLoginDto.Email!);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Auth");
        }
  
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


     
        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanılıyor.");
                ViewBag.ErrorMessage = "Bu e-posta adresi zaten kullanılıyor.";
                return RedirectToAction("Register", "Auth");
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return RedirectToAction("Login", "Auth");
            }

            return RedirectToAction("Register", "Auth");
        }
       
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPasswordSendMailCode(string mail)
        {
            //_authService.SendMailCodeByResetPassword(mail);

            return RedirectToAction("EntryCode", "Auth");
        }

        [HttpGet]
        public IActionResult EntryCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EntryCode(string enteredCode)
        {
            var activated = _authService.VerifyActivationCode(enteredCode);

            if (activated == true)
            {
                return RedirectToAction("ResetPassword","Auth");
            }
            
            return View();
        }


        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }



        [HttpPost]
        public IActionResult ResetPassword(string newPassword, string confirmPassword)
        {
            var resetPasswordDto = new ResetPasswordDto 
            {
                Email = "mail" ,
                NewPassword = newPassword ,
                ConfirmPassword = confirmPassword,
                Token = "token"
            };

            var resetResult = _authService.ResetPassword(resetPasswordDto);
            if (resetResult.Success)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", resetResult.Message);
            return View();
        }
        

       
       
    }
}
