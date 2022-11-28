using Event.API.Entities;

namespace Event.API.Services
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventEntity>> GetEventsAsync();
        Task<bool> EventExistsAsync(int eventId);
        Task<EventEntity?> GetEventEntityAsync(int eventId);
        Task AddEvent(EventEntity eventEntity);
        void DeleteEvent(EventEntity eventEntity);
        Task<bool> SaveChangesAsync();
    }
}
