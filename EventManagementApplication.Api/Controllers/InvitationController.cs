using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _invitationService;

        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }
        [HttpGet]
        [Route("GetAllInvitation")]
        public IActionResult GetAllInvitation()
        {
            var invitationList = _invitationService.GetAll();
            return Ok(invitationList);
        }

        [HttpGet]
        [Route("GetInvitation{id}")]
        public IActionResult InvitationSingle(int id)
        {
            var invitatiın = _invitationService.GetById(id);
            return Ok(invitatiın);
        }

        [HttpPost]
        [Route("AddInvitation")]
        public IActionResult AddInvitation(Invitation entity)
        {
            _invitationService.Create(entity);
            return Ok();
        }

        //?
        [HttpPost]
        [Route("GetAllInvitation")]
        public IActionResult UpdateEvent(Invitation entity)
        {
            _invitationService.Update(entity);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteInvitation")]
        public IActionResult DeleteInvitation(int id)
        {
            _invitationService.Delete(id);
            return Ok();
        }
    }
}
