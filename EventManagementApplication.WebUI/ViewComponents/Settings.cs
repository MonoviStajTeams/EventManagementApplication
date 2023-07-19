using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class Settings:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
