using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class Animals9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainAnimal_AspNetUsers_ApplicationUserId1",
                table: "MainAnimal");

            migrationBuilder.DropIndex(
                name: "IX_MainAnimal_ApplicationUserId1",
                table: "MainAnimal");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MainAnimal");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "MainAnimal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "MainAnimal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "MainAnimal",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_ApplicationUserId1",
                table: "MainAnimal",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MainAnimal_AspNetUsers_ApplicationUserId1",
                table: "MainAnimal",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
