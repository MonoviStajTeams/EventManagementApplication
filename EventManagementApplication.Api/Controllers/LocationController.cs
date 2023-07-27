using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("NotificationList")]
        public IActionResult LocationList()
        {
            var locationlist = _locationService.GetAll();
            return Ok(locationlist);
        }


        [HttpPost]
        [Route("AddLocation")]
        public IActionResult AddLocation(Location location)
        {
            _locationService.Create(location);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateLocation")]
        public IActionResult UpdateLocation(Location location)
        {
            _locationService.Update(location);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteLocation{id}")]
        public IActionResult DeleteLocation(int id)
        {
            _locationService.Delete(id);
            return Ok();
        }
    }
}

