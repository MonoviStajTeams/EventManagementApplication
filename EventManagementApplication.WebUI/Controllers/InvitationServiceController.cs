using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class InvitationServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
