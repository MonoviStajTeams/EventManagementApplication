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
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var eventList = _eventService.GetByType();
            return Ok(eventList);
        }
        [HttpGet]
        [Route("GetByType")]
        public IActionResult GetByType(string type)
        {
            var typeEventList = _eventService.GetByType(type);
            return Ok(typeEventList);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetEventById(int id)
        {
            var role = _eventService.GetById(id);
            return Ok(role);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult AddEvent(Event entity)
        {
            _eventService.Create(entity);
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateEvent(Event entity)
        {
            _eventService.Update(entity);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            _eventService.Delete(id);
            return Ok();
        }


        [HttpGet]
        [Route("GetInactiveEventsByUserId/{id}")]
        public IActionResult GetInactiveEventsByUserId(int id)
        {
            var eventList = _eventService.GetInactiveEventsByUserId(id);
            return Ok(eventList);
        }

        [HttpPost]
        [Route("ActivateEvent")]

        public IActionResult ActivateEvent(Event eventEntity)
        {
            _eventService.ActivateEvent(eventEntity);
            return Ok();
        }


        [HttpGet]
        [Route("GetAllByUserId/{id}")]

        public IActionResult GetAllByUserId(int id)
        {
            var getEvent = _eventService.GetAllByUserId(id);
            return Ok(getEvent);
        }


    }
}
