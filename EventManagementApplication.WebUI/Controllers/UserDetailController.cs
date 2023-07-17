using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class UserDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
