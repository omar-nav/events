using Event.API.Entities;

namespace Event.API.Services
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventEntity>> GetEventsAsync();
        Task<(IEnumerable<EventEntity>, PaginationMetadata)> GetEventsAsync(string? searchName, string? searchSlug, 
            string? searchCategory, string? searchBrand, int pageNumber, int pageSize);
        Task<bool> EventExistsAsync(int eventId);
        Task<EventEntity?> GetEventEntityAsync(int eventId);
        Task AddEvent(EventEntity eventEntity);
        void DeleteEvent(EventEntity eventEntity);
        Task<bool> SaveChangesAsync();
    }
}
