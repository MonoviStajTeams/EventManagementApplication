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
        public IActionResult GetAll()
        {
            var invitationList = _invitationService.GetAll();
            return Ok(invitationList);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var invitatiın = _invitationService.GetById(id);
            return Ok(invitatiın);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Add(Invitation entity)
        {
            _invitationService.Create(entity);
            return Ok();
        }

        //?
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Invitation entity)
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

        [HttpGet]
        [Route("SendInvitationMail/{id}")]
        public IActionResult SendInvitationMail(int id)
        {
            _invitationService.SendInvitationMail(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetLastInvitationId")]
        public IActionResult GetLastInvitationId()
        {
            var lastId = _invitationService.GetLastInvitationId();
            return Ok(lastId);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _invitationService.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetInvitationsByUserId/{id}")]
        public IActionResult GetInvitationsByUserId(int id)
        {
            var invitations = _invitationService.GetInvitationsByUserId(id);
            return Ok(invitations);
        }
    }
}
