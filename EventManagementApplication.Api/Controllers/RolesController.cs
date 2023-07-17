using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult RoleList()
        {
            var roles = _roleService.GetAll();
            return Ok(roles);
        }


        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddRole(Role role)
        {
            _roleService.Create(role);
            return Ok();
        }


        [HttpPost]
        [Route("UpdateRole")]
        public IActionResult UpdateRole(Role role)
        {
            _roleService.Update(role);
            return Ok();
        }
    }
}
