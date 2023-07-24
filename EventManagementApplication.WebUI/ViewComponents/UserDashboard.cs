using EventManagementApplication.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class UserDashboard:ViewComponent
    {
        private readonly IUserService _userService;

        public UserDashboard(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Session.GetString("Email")!;
            var user = _userService.GetByMail(email!);


            return View(user);
        }
    }
}
