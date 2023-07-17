using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    public class UserDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
