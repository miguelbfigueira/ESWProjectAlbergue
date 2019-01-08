using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserCreaterIdId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderIdId",
                table: "Reminder");

            migrationBuilder.RenameColumn(
                name: "UserReminderIdId",
                table: "Reminder",
                newName: "UserReminderId");

            migrationBuilder.RenameColumn(
                name: "UserCreaterIdId",
                table: "Reminder",
                newName: "UserCreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserReminderIdId",
                table: "Reminder",
                newName: "IX_Reminder_UserReminderId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserCreaterIdId",
                table: "Reminder",
                newName: "IX_Reminder_UserCreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_UserCreaterId",
                table: "Reminder",
                column: "UserCreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderId",
                table: "Reminder",
                column: "UserReminderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserCreaterId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderId",
                table: "Reminder");

            migrationBuilder.RenameColumn(
                name: "UserReminderId",
                table: "Reminder",
                newName: "UserReminderIdId");

            migrationBuilder.RenameColumn(
                name: "UserCreaterId",
                table: "Reminder",
                newName: "UserCreaterIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserReminderId",
                table: "Reminder",
                newName: "IX_Reminder_UserReminderIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserCreaterId",
                table: "Reminder",
                newName: "IX_Reminder_UserCreaterIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_UserCreaterIdId",
                table: "Reminder",
                column: "UserCreaterIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderIdId",
                table: "Reminder",
                column: "UserReminderIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
