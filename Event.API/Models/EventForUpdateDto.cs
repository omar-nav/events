using Event.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Event.API.Models
{
    public class EventForUpdateDto
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Brand { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Slug { get; set; } = string.Empty;
        public StatusCode Status { get; set; }
    }
}
