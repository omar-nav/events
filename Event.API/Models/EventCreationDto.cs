using Event.API.Models.Enums;

namespace Event.API.Models
{
    public class EventCreationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public StatusCode Status { get; set; }
    }
}
