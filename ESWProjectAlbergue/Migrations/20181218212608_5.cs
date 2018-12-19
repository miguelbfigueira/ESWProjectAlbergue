using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserReminderId",
                table: "Reminder");

            migrationBuilder.AddColumn<string>(
                name: "UserReminderIdId",
                table: "Reminder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_UserReminderIdId",
                table: "Reminder",
                column: "UserReminderIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderIdId",
                table: "Reminder",
                column: "UserReminderIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderIdId",
                table: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_UserReminderIdId",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "UserReminderIdId",
                table: "Reminder");

            migrationBuilder.AddColumn<int>(
                name: "UserReminderId",
                table: "Reminder",
                nullable: false,
                defaultValue: 0);
        }
    }
}
