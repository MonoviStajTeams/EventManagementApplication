using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class LocationServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
