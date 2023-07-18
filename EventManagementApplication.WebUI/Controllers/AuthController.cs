using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (false) // Mail Kontrolü Yapılacak
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanılıyor.");
                ViewBag.ErrorMessage = "Bu e-posta adresi zaten kullanılıyor.";
                return View(user);
            }
            else if (false) // User Register İşlemi Yapılacak
            {
               
                return RedirectToAction("Login", "Auth");
            }

            return View();

        }



    }
}
