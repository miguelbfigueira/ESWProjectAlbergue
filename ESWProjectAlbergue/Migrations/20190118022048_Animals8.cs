using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class Animals8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "test");

            migrationBuilder.RenameColumn(
                name: "testId",
                table: "test",
                newName: "test2Id");

            migrationBuilder.AddColumn<int>(
                name: "AnimalAgeTypeId",
                table: "test",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Designacao",
                table: "test",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_test_AnimalAgeTypeId",
                table: "test",
                column: "AnimalAgeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_test_AAgeType_AnimalAgeTypeId",
                table: "test",
                column: "AnimalAgeTypeId",
                principalTable: "AAgeType",
                principalColumn: "AAgeTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_AAgeType_AnimalAgeTypeId",
                table: "test");

            migrationBuilder.DropIndex(
                name: "IX_test_AnimalAgeTypeId",
                table: "test");

            migrationBuilder.DropColumn(
                name: "AnimalAgeTypeId",
                table: "test");

            migrationBuilder.DropColumn(
                name: "Designacao",
                table: "test");

            migrationBuilder.RenameColumn(
                name: "test2Id",
                table: "test",
                newName: "testId");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "test",
                nullable: true);
        }
    }
}
