using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult RoleList()
        {
            var roles = _roleService.GetAll();
            return View(roles);
        }


        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            _roleService.Create(role);
            return RedirectToAction("RoleList", "Role");
        }

        [HttpGet]
        public IActionResult UpdateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateRole(Role role)
        {
            _roleService.Create(role);
            return RedirectToAction("RoleList", "Role");
        }

        public IActionResult DeleteRole(int id)
        {
            _roleService.Delete(id);
            return RedirectToAction("RoleList", "Role");
        }
    }
}
