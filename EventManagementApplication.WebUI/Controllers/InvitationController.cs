using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class InvitationController : Controller
    {
        private readonly IInvitationService _invitationService;
        private readonly IUserService _userService;
        public InvitationController(IInvitationService invitationService, IUserService userService)
        {
            _invitationService = invitationService;
            _userService = userService;
        }

        public IActionResult InvitationList()
        {
            var invitationList = _invitationService.GetAll();
            return View(invitationList);
        }

        [HttpGet]
        public IActionResult InvitationSingle(int id)
        {
            var invitatiın = _invitationService.GetById(id);
            return View(invitatiın);
        }


        [HttpGet]
        public IActionResult AddInvitation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvitation(Invitation entity)
        {
            var lastInvitationId = _invitationService.GetLastInvitationId();
            entity.Id = lastInvitationId;
            string email = HttpContext.Session.GetString("Email")!;

            var user = _userService.GetByMail(email!);
            entity.UserId = user.Id;
            _invitationService.Create(entity);
            
            return RedirectToAction("AddUsersInvitation", "Invitation" , new {id = lastInvitationId });
        }

        [HttpGet]
        public IActionResult UpdateInvitation(int id)
        {
            var invitation = _invitationService.GetById(id);
            return View(invitation);
        }

        [HttpPost]
        public IActionResult UpdateEvent(Invitation entity)
        {
            _invitationService.Update(entity);
            return RedirectToAction("GetAllInvitation", "GetAllInvitation");
        }


        public IActionResult DeleteInvitation(int id)
        {
            _invitationService.Delete(id);
            return RedirectToAction("InvitationList", "Invitation");
        }

        public IActionResult AddUsersInvitation(int id)
        {
            ViewBag.InvitationId = id;
            ViewBag.Users = _invitationService.GetUsers();
            return View();
        }
      
    }
}
