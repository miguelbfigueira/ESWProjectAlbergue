using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class BreedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnimalBreed",
                columns: new[] { "Id", "Behavior", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Indefinida" },
                    { 2, 2, "Beagle" },
                    { 3, 0, "Husky" },
                    { 4, 4, "Labrador" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalBreed",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnimalBreed",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnimalBreed",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnimalBreed",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
