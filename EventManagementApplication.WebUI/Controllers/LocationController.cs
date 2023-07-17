using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public IActionResult GetAll()
        {
            var locationList = _locationService.GetAll();
            return View(locationList);
        }

        [HttpGet]
        public IActionResult LocationSingle(int id)
        {
            var locationById = _locationService.GetById(id);
            return View(locationById);
        }


        [HttpGet]
        public IActionResult AddLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLocation(Location location)
        {
            _locationService.Create(location);
            return RedirectToAction("Index", "Location");
        }

        [HttpGet]
        public IActionResult UpdateLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateLocation(Location location)
        {
            _locationService.Update(location);
            return RedirectToAction("Index", "Location");
        }


        public IActionResult DeleteLocation(int id)
        {
            _locationService.Delete(id);
            return RedirectToAction("Index", "Location");
        }

  


    }
}
