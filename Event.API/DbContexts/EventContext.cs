using Event.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Event.API.DbContexts
{
    public class EventContext : DbContext
    {
        public DbSet<EventEntity> EventEntities { get; set; } = null!;

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>()
                .HasData(
                new EventEntity("Wedding of Jaime Olivares")
                {
                    Id = 1,
                    Category = "Wedding.",
                    Brand = "Nike",
                    Slug = "www.nikewedding.com",
                    Status = Models.Enums.StatusCode.Scheduled
                },
                new EventEntity("Quinceñera de la familia Pereira")
                {
                    Id = 2,
                    Category = "Quinceñera",
                    Brand = "Saga",
                    Slug = "www.sagaquincenera.com",
                    Status = Models.Enums.StatusCode.Completed
                },
                new EventEntity("Quinceñera de la familia Pereira")
                {
                    Id = 3,
                    Category = "Wedding.",
                    Brand = "Nike",
                    Slug = "www.nikewedding.com",
                    Status = Models.Enums.StatusCode.InProgress
                },
                new EventEntity("Birthday of Juan Pablo")
                {
                    Id = 4,
                    Category = "Birthday.",
                    Brand = "Adidas",
                    Slug = "www.addidasbirthday.com",
                    Status = Models.Enums.StatusCode.InProgress
                },
                new EventEntity("Birthday of Julio")
                {
                    Id = 5,
                    Category = "Birthday.",
                    Brand = "Puma",
                    Slug = "www.pumabirthday.com",
                    Status = Models.Enums.StatusCode.InProgress
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
