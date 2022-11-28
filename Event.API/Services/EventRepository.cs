using Event.API.DbContexts;
using Event.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event.API.Services
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;
        public EventRepository(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<EventEntity>> GetEventsAsync()
        {
            return await _context.EventEntities.OrderBy(e => e.Name).ToListAsync();
        }

        public async Task<EventEntity?> GetEventEntityAsync(int eventId)
        {
            return await _context.EventEntities
                .Where(e => e.Id == eventId).FirstOrDefaultAsync();
        }
    }
}
