using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class NotificationServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
