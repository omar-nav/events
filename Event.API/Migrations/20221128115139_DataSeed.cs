using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventEntities",
                columns: new[] { "Id", "Brand", "Category", "Name", "Slug", "Status" },
                values: new object[,]
                {
                    { 1, "Nike", "Wedding.", "Wedding of Jaime Olivares", "www.nikewedding.com", 1 },
                    { 2, "Saga", "Quinceñera", "Quinceñera de la familia Pereira", "www.sagaquincenera.com", 3 },
                    { 3, "Nike", "Wedding.", "Quinceñera de la familia Pereira", "www.nikewedding.com", 2 },
                    { 4, "Adidas", "Birthday.", "Birthday of Juan Pablo", "www.addidasbirthday.com", 2 },
                    { 5, "Puma", "Birthday.", "Birthday of Julio", "www.pumabirthday.com", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventEntities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventEntities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventEntities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventEntities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventEntities",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
