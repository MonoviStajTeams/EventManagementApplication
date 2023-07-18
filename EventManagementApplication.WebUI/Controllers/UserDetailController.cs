using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly IUserDetailService _userDetailService;

        public UserDetailController(IUserDetailService userDetailService)
        {
            _userDetailService = userDetailService;
        }

        public IActionResult UserDetailList()
        {
            var userDetails = _userDetailService.GetAll();
            return View(userDetails);
        }

        [HttpGet]
        public IActionResult AddUserDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUserDetail(UserDetail userDetail)
        {
            _userDetailService.Create(userDetail);
            return RedirectToAction("UserDetailList", controllerName: "UserDetail");
        }

        [HttpGet]
        public IActionResult UpdateUserDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateUserDetail(UserDetail userDetail)
        {
            _userDetailService.Update(userDetail);
            return RedirectToAction("UserDetailList", controllerName: "UserDetail");
        }

        public IActionResult DeleteUserDetail(int id)
        {
            _userDetailService.Delete(id);
            return RedirectToAction("UserDetailList", controllerName: "UserDetail");
        }
    }
}
