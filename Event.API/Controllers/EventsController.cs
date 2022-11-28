using Event.API.Models;
using Event.API.Models.Enums;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [Route("update")]
        [HttpPatch("{eventId}")]
        public ActionResult UpdateEvent(int eventId, JsonPatchDocument<EventForUpdateDto> patchDocument)
        {
            var eventFromStore = EventsDataStore.Current.Events.FirstOrDefault(e => e.Id == eventId);

            if (eventFromStore == null)
            {
                return NotFound();
            }

            var eventToPatch = new EventForUpdateDto()
                {   
                    Name = eventFromStore.Name,
                    Category = eventFromStore.Category,
                    Brand = eventFromStore.Brand, 
                    Slug = eventFromStore.Slug,
                    Status = eventFromStore.Status
                };

            patchDocument.ApplyTo(eventToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(eventToPatch))
            {
                return BadRequest(ModelState);
            }

            eventFromStore.Name = eventToPatch.Name;
            eventFromStore.Category = eventToPatch.Category;
            eventFromStore.Brand = eventToPatch.Brand;
            eventFromStore.Slug = eventToPatch.Slug;
            eventFromStore.Status = eventToPatch.Status;

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        public ActionResult DeletePointOfInterest(int eventId)
        {
            var eventFromStore = EventsDataStore.Current.Events.FirstOrDefault(e => e.Id == eventId);

            if (eventFromStore == null)
            {
                return NotFound();
            }

            EventsDataStore.Current.Events.Remove(eventFromStore);
            return NoContent();
        }
    }
}
