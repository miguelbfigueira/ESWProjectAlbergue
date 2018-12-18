using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_CreaterId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserToReminderId",
                table: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_CreaterId",
                table: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_UserToReminderId",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "CreaterId",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "UserToReminderId",
                table: "Reminder");

            migrationBuilder.AddColumn<int>(
                name: "UserCreaterId",
                table: "Reminder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserReminderId",
                table: "Reminder",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCreaterId",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "UserReminderId",
                table: "Reminder");

            migrationBuilder.AddColumn<string>(
                name: "CreaterId",
                table: "Reminder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserToReminderId",
                table: "Reminder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_CreaterId",
                table: "Reminder",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_UserToReminderId",
                table: "Reminder",
                column: "UserToReminderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_CreaterId",
                table: "Reminder",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_UserToReminderId",
                table: "Reminder",
                column: "UserToReminderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
