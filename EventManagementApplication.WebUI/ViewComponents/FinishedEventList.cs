using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class FinishedEventList : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
