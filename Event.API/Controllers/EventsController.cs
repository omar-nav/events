using AutoMapper;
using Event.API.Entities;
using Event.API.Models;
using Event.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace Event.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ??
                throw new ArgumentNullException(nameof(eventRepository));

            _mapper= mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var eventEntities = await _eventRepository.GetEventsAsync();
            return Ok(_mapper.Map<IEnumerable<EventDto>>(eventEntities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var eventToReturn = await _eventRepository.GetEventEntityAsync(id);

            if (eventToReturn == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EventDto>(eventToReturn));
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(EventCreationDto eventToCreate)
        {
            var finalEvent = _mapper.Map<EventEntity>(eventToCreate);

            await _eventRepository.AddEvent(finalEvent);

            await _eventRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = finalEvent.Id }, eventToCreate);
        }

        [HttpPatch, Route("update/{eventId}")]
        public async Task<ActionResult> PartiallyUpdateEvent(int eventId, JsonPatchDocument<EventForUpdateDto> patchDocument)
        {
            if (!await _eventRepository.EventExistsAsync(eventId))
            {
                return NotFound();
            }

            var eventEntity = await _eventRepository.GetEventEntityAsync(eventId);

            var eventToPatch = _mapper.Map<EventForUpdateDto>(eventEntity);

            patchDocument.ApplyTo(eventToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(eventToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(eventToPatch, eventEntity);
            await _eventRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        public async Task<ActionResult> DeletePointOfInterest(int eventId)
        {
            if (!await _eventRepository.EventExistsAsync(eventId))
            {
                return NotFound();
            }

            var eventEntity = await _eventRepository.GetEventEntityAsync(eventId);

            _eventRepository.DeleteEvent(eventEntity);
            await _eventRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
