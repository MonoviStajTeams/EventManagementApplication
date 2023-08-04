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
        [Route("GetAll")]
        public IActionResult GetAllInvitation()
        {
            var invitationList = _invitationService.GetAll();
            return Ok(invitationList);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult InvitationSingle(int id)
        {
            var invitatiın = _invitationService.GetById(id);
            return Ok(invitatiın);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult AddInvitation(Invitation entity)
        {
            _invitationService.Create(entity);
            return Ok();
        }

        //?
        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateEvent(Invitation entity)
        {
            _invitationService.Update(entity);
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteInvitation(int id)
        {
            _invitationService.Delete(id);
            return Ok();
        }
    }
}
