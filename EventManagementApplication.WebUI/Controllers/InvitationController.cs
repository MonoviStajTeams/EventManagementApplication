using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class InvitationController : Controller
    {
        private readonly IInvitationService _invitationService;

        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        public IActionResult GetAllInvitation()
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
            _invitationService.Create(entity);
            return RedirectToAction("GetAllInvitation", "GetAllInvitation");
        }

        [HttpGet]
        public IActionResult UpdateInvitation()
        {
            return View();
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
            return RedirectToAction("GetAllInvitation", "GetAllInvitation");
        }
    }
}
