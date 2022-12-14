using Event.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Event.API.Models
{
    public class EventCreationDto
    {
        [Required(ErrorMessage = "A name value should be provided.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "A category value should be provided.")]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        [Required(ErrorMessage = "A brand value should be provided.")]
        [MaxLength(50)]
        public string Brand { get; set; } = string.Empty;
        [Required(ErrorMessage = "A slug value should be provided.")]
        [MaxLength(50)]
        public string Slug { get; set; } = string.Empty;
        [Required(ErrorMessage = "A status value should be provided.")]
        public StatusCode Status { get; set; }
    }
}
