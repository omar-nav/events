using Event.API.Entities;

namespace Event.API.Services
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventEntity>> GetEventsAsync();

        Task<EventEntity?> GetEventEntityAsync(int eventId);
        
    }
}
