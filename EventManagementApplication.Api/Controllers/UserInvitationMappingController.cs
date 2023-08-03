using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInvitationMappingController : ControllerBase
    {
        private readonly IUserInvitationMappingService _userİnvitationMappingService;
        
        public UserInvitationMappingController(IUserInvitationMappingService userInvitationMappingService)
        {
            _userİnvitationMappingService = userInvitationMappingService;   
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var userInvitationMappingServiceGetById = _userİnvitationMappingService.GetById(id);
            return Ok(userInvitationMappingServiceGetById);
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var userInvitationMappingServiceGetAll = _userİnvitationMappingService.GetAll();
            return Ok(userInvitationMappingServiceGetAll);
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateMapping(UserInvitationMapping userInvitationMapping)
        {
            _userİnvitationMappingService.Create(userInvitationMapping);
            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateMapping(UserInvitationMapping userInvitationMapping)
        {
            _userİnvitationMappingService.Update(userInvitationMapping);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteMapping(int id)
        {
            _userİnvitationMappingService.Delete(id);
            return Ok();
        }
        [HttpPost]
        [Route("AcceptEvent")]
        public IActionResult AcceptEvent(int id)
        { 
            _userİnvitationMappingService.AcceptEvent(id);
            return Ok();
        }
    }
}
