using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Entities.dtos;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public UserController(IUserService userService, IUserDetailService userDetailService)
        {
            _userService = userService;
            _userDetailService = userDetailService;
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

        [HttpPost]
        public async Task<IActionResult> ProfileSettings(ProfileSettingsDto settingsDto, IFormFile file)
        {
            string email = HttpContext.Session.GetString("Email")!;

            var user = _userService.GetByMail(email!);
            user.FirstName = settingsDto.FirstName;
            user.LastName = settingsDto.LastName;
            _userService.Update(user);


            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = "images/user/" + fileName;

                using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var userDetail = _userDetailService.GetUserDetailByUserId(user.Id);
                if (userDetail == null)
                {
                    var detail = new UserDetail
                    {
                        PhoneNumber = settingsDto.PhoneNumber,
                        ProfileImagePath = filePath,
                        UserId = user.Id,
                    };
                    _userDetailService.Create(detail);
                }
                else
                {
                    userDetail.PhoneNumber = settingsDto.PhoneNumber;
                    userDetail.ProfileImagePath = filePath;
                    userDetail.UserId = user.Id;
                    _userDetailService.Update(userDetail);
                }
            }
          
            return RedirectToAction("ProfileSettings","User");
        }


    }
}
