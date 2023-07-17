using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [Route("EventList")]
        public IActionResult EventList()
        {
            var eventList = _eventService.GetAll();
            return Ok(eventList);
        }


        [HttpGet]
        [Route("GetEventyId{id}")]
        public IActionResult GetEventById(int id)
        {
            var role = _eventService.GetById(id);
            return Ok(role);
        }



        [HttpPost]
        public IActionResult AddEvent(Event entity)
        {
            _eventService.Create(entity);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateEvent(Event entity)
        {
            _eventService.Update(entity);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEvent(int id)
        {
            _eventService.Delete(id);
            return Ok();
        }


        [HttpGet]
        [Route("GetInactiveEvents{id}")]
        public IActionResult GetInactiveEventsByUserId(int id)
        {
            var eventList = _eventService.GetInactiveEventsByUserId(id);
            return Ok(eventList);
        }

       
    }
}
