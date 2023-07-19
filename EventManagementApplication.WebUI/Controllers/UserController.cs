using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult UserList()
        {
            var user = _userService.GetAll();
            return View(user);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userService.Create(user);
            return RedirectToAction("UserList", controllerName: "User");
        }

        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            _userService.Update(user);
            return RedirectToAction("UserList", controllerName: "User");
        }

        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("UserList", controllerName: "User");
        }
        public IActionResult UserDashboard()
        {
            return View();
        }

        public IActionResult ProfileSettings()
        {
            return View();
        }
    }
}
