using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class ProfileButton : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Session.GetString("Email")!;
            if (email == null)
            {
                ViewBag.User = false;
                return View();
            }
            else
            {
                ViewBag.User = true;
                return View();
            }
        }
    }
}
