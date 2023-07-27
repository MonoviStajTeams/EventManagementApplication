using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class ActivityLog:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
