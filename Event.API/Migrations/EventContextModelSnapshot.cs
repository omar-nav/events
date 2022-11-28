﻿// <auto-generated />
using Event.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event.API.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Event.API.Entities.EventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EventEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Nike",
                            Category = "Wedding.",
                            Name = "Wedding of Jaime Olivares",
                            Slug = "www.nikewedding.com",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Saga",
                            Category = "Quinceñera",
                            Name = "Quinceñera de la familia Pereira",
                            Slug = "www.sagaquincenera.com",
                            Status = 3
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Nike",
                            Category = "Wedding.",
                            Name = "Quinceñera de la familia Pereira",
                            Slug = "www.nikewedding.com",
                            Status = 2
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Adidas",
                            Category = "Birthday.",
                            Name = "Birthday of Juan Pablo",
                            Slug = "www.addidasbirthday.com",
                            Status = 2
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Puma",
                            Category = "Birthday.",
                            Name = "Birthday of Julio",
                            Slug = "www.pumabirthday.com",
                            Status = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
