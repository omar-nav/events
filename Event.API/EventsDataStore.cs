using Event.API.Models;

namespace Event.API
{
    public class EventsDataStore
    {
        public List<EventDto> Events { get; set; }
        public static EventsDataStore Current { get; } = new EventsDataStore();

        public EventsDataStore()
        {
            // init dummy data
            Events = new List<EventDto>()
            {
                new EventDto()
                {
                     Id = 1,
                     Name = "Wedding of Jaime Olivares",
                     Category = "Wedding.",
                     Brand = "Nike",
                     Slug = "www.nikewedding.com",
                     Status = Models.Enums.StatusCode.Scheduled
                },
                new EventDto()
                {
                     Id = 2,
                     Name = "Quinceñera de la familia Pereira",
                     Category = "Quinceñera",
                     Brand = "Saga",
                     Slug = "www.sagaquincenera.com",
                     Status = Models.Enums.StatusCode.Scheduled
                },
                new EventDto()
                {
                     Id = 3,
                     Name = "Funeral of Alan Garcia",
                     Category = "Funeral",
                     Brand = "Coca Cola",
                     Slug = "www.cocacolafuneral.com",
                     Status = Models.Enums.StatusCode.Completed
                },
            };

        }

    }
}
