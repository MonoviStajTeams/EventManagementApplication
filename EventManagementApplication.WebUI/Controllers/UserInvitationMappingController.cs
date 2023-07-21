using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Entities.dtos;
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


        [HttpPost]
        public IActionResult AddUserInvitationMapping([FromBody] AddUserInvitationMappingModel model)
        {
            if (model == null || model.UserIds == null || model.UserIds.Length == 0 || model.InvitationId == 0)
            {
                ViewBag.Error = "Seçilen kullanıcılar geçerli değil.";
                return RedirectToAction("AddUserInvitationMapping");
            }

            foreach (var userId in model.UserIds)
            {
                var userInvitationMapping = new UserInvitationMapping
                {
                    InvitedId = userId,
                    InvitationId = model.InvitationId
                };
                _userInvitationMappingService.Create(userInvitationMapping);
            }

            ViewBag.SuccessMessage = "Kullanıcılar başarıyla davet edildi.";
            return RedirectToAction("InvitationList","Invitation");
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

