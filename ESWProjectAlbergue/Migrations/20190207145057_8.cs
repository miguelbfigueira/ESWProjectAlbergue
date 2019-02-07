using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "PerfectAnimal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Percentagem",
                table: "PerfectAnimal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PerfectAnimal_AnimalId",
                table: "PerfectAnimal",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfectAnimal_Animal_AnimalId",
                table: "PerfectAnimal",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfectAnimal_Animal_AnimalId",
                table: "PerfectAnimal");

            migrationBuilder.DropIndex(
                name: "IX_PerfectAnimal_AnimalId",
                table: "PerfectAnimal");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "PerfectAnimal");

            migrationBuilder.DropColumn(
                name: "Percentagem",
                table: "PerfectAnimal");
        }
    }
}
