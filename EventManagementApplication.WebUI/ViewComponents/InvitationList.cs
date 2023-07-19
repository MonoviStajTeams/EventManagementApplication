using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class InvitationList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
