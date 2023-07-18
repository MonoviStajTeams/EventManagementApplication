using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return Ok();
        }

        public IActionResult Register(User user)
        {
            return Ok();
        }
    }
}
