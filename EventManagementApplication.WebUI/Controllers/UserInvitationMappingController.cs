using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class UserInvitationMappingController : Controller
    {
        private readonly IUserInvitationMappingService _userInvitationMappingService;

        public UserInvitationMappingController(IUserInvitationMappingService userInvitationMappingService)
        {
            _userInvitationMappingService = userInvitationMappingService;
        }

        public IActionResult GetAll()
        {
            var userInvitationMappingList = _userInvitationMappingService.GetAll();
            return View(userInvitationMappingList);
        }

        [HttpGet]
        public IActionResult UserInvitationMappingSingle(int id)
        {
            var userInvitationMappingById = _userInvitationMappingService.GetById(id);
            return View(userInvitationMappingById);
        }


        [HttpGet]
        public IActionResult AddUserInvitationMapping()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUserInvitationMapping(UserInvitationMapping userInvitationMapping)
        {
            _userInvitationMappingService.Create(userInvitationMapping);
            return RedirectToAction("Index", "UserInvitationMapping");
        }

        [HttpGet]
        public IActionResult UpdateUserInvitationMapping()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateUserInvitationMapping(UserInvitationMapping
            userInvitationMapping)
        {
            _userInvitationMappingService.Update(userInvitationMapping);
            return RedirectToAction("Index", "UserInvitationMapping");
        }


        public IActionResult DeleteUserInvitationMapping(int id)
        {
            _userInvitationMappingService.Delete(id);
            return RedirectToAction("Index", "UserInvitationMapping");
        }




    }
}

