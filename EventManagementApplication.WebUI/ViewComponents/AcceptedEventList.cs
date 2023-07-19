using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class AcceptedEventList:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
