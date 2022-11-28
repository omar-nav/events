using Event.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event.API.Entities
{
    public class EventEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Brand { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Slug { get; set; } = string.Empty;
        [MaxLength(50)]
        public StatusCode Status { get; set; }
        public EventEntity(string name)
        {
            Name = name;
        }
    }
}
