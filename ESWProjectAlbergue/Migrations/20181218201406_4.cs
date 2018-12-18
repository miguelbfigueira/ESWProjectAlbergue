using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCreaterId",
                table: "Reminder");

            migrationBuilder.AddColumn<string>(
                name: "UserCreaterIdId",
                table: "Reminder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_UserCreaterIdId",
                table: "Reminder",
                column: "UserCreaterIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_UserCreaterIdId",
                table: "Reminder",
                column: "UserCreaterIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserCreaterIdId",
                table: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_UserCreaterIdId",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "UserCreaterIdId",
                table: "Reminder");

            migrationBuilder.AddColumn<int>(
                name: "UserCreaterId",
                table: "Reminder",
                nullable: false,
                defaultValue: 0);
        }
    }
}
