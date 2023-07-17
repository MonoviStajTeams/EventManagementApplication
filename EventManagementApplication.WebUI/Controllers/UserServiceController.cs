using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class UserServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
