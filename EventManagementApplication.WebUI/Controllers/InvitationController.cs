using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class InvitationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
