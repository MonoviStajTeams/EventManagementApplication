using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult UserList()
        {
            var userList = _userService.GetAll();
            return Ok(userList);
        }


        [HttpGet]
        [Route("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }



        [HttpPost]
        [Route("Create")]
        public IActionResult AddUser(User user)
        {
            _userService.Create(user);
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateUser(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

    }
}
