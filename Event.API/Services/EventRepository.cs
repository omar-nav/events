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

        public async Task<IEnumerable<EventEntity>> GetEventsAsync(string? searchName, string? searchSlug, 
            string? searchCategory, string? searchBrand)
        {
            if (string.IsNullOrEmpty(searchName)
                && string.IsNullOrEmpty(searchSlug)
                && string.IsNullOrEmpty(searchCategory)
                && string.IsNullOrEmpty(searchBrand))
            {
                return await GetEventsAsync();
            }

            var collection = _context.EventEntities as IQueryable<EventEntity>;

            if (!string.IsNullOrWhiteSpace(searchName) || !string.IsNullOrWhiteSpace(searchSlug) 
                || !string.IsNullOrWhiteSpace(searchCategory) || !string.IsNullOrWhiteSpace(searchBrand))
            {
                searchName = searchName?.Trim() ?? searchName;
                searchSlug = searchSlug?.Trim() ?? searchSlug;
                searchCategory = searchCategory?.Trim() ?? searchCategory;
                searchBrand = searchBrand?.Trim() ?? searchBrand;

                collection = collection.Where(e =>
                    !string.IsNullOrEmpty(searchName) && e.Name.Contains(searchName)
                || (!string.IsNullOrEmpty(searchSlug) && e.Slug.Contains(searchSlug))
                || (!string.IsNullOrEmpty(searchCategory) && e.Category.Contains(searchCategory))
                || (!string.IsNullOrEmpty(searchBrand) && e.Brand.Contains(searchBrand)));
            }

            return await collection.OrderBy(e => e.Name).ToListAsync();
        }

        public async Task<bool> EventExistsAsync(int eventId)
        {
            return await _context.EventEntities.AnyAsync(e => e.Id == eventId);
        }

        public async Task<EventEntity?> GetEventEntityAsync(int eventId)
        {
            return await _context.EventEntities
                .Where(e => e.Id == eventId).FirstOrDefaultAsync();
        }

        public Task AddEvent(EventEntity eventEntity)
        {
            _context.Add(eventEntity);
            return Task.CompletedTask;
        }

        public void DeleteEvent(EventEntity eventEntity)
        {
            _context.Remove(eventEntity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
