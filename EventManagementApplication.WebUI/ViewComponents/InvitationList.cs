using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class InvitationList:ViewComponent
    {
        private readonly IInvitationService _invitationService;
        private readonly IUserService _userService;

        public InvitationList(IInvitationService invitationService, IUserService userService)
        {
            _invitationService = invitationService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Session.GetString("Email")!;

            var user = _userService.GetByMail(email!);
            var invitationList = _invitationService.GetInvitationsByUserId(user.Id);
            return View(invitationList);
        }
    }
}
