using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class UserDetailServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
