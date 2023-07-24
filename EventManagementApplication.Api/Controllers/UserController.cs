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
        [Route("UserList")]
        public IActionResult UserList()
        {
            var userList = _userService.GetAll();
            return Ok(userList);
        }


        [HttpGet]
        [Route("GetUserId{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }



        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _userService.Create(user);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

    }
}
