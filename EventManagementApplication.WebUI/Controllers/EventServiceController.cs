using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class EventServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
