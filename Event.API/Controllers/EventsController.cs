using Event.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<EventDto> GetEvents()
        {
            return Ok(EventsDataStore.Current.Events);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDto> GetEvent(int id)
        {
            var eventToReturn = EventsDataStore.Current.Events
                .FirstOrDefault(e => e.Id == id);

            if (eventToReturn == null)
            {
                return NotFound();
            }

            return Ok(eventToReturn);
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(EventCreationDto eventToCreate)
        {
            var maxEventId = EventsDataStore.Current.Events.Select(e => e.Id).Max(id => id);

            var finalEvent = new EventDto()
            {
                Id = ++maxEventId,
                Name = eventToCreate.Name,
                Category = eventToCreate.Category,
                Brand = eventToCreate.Brand,
                Slug = eventToCreate.Slug,
                Status = eventToCreate.Status,
            };

            EventsDataStore.Current.Events.Add(finalEvent);

            return Ok(finalEvent);
        }
    }
}
