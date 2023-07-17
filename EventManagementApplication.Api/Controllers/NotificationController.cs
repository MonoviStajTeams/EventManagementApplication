using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
