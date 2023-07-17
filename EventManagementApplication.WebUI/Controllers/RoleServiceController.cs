using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class RoleServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
