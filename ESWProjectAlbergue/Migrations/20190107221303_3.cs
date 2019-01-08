using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserCreaterId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderId",
                table: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_UserCreaterId",
                table: "Reminder");

            migrationBuilder.RenameColumn(
                name: "UserReminderId",
                table: "Reminder",
                newName: "UserReminderIdId");

            migrationBuilder.RenameColumn(
                name: "UserCreaterId",
                table: "Reminder",
                newName: "UserReminder");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserReminderId",
                table: "Reminder",
                newName: "IX_Reminder_UserReminderIdId");

            migrationBuilder.AlterColumn<string>(
                name: "UserReminder",
                table: "Reminder",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreater",
                table: "Reminder",
                nullable: true);

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
                name: "FK_Reminder_AspNetUsers_UserCreaterIdId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_AspNetUsers_UserReminderIdId",
                table: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_UserCreaterIdId",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "UserCreater",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "UserCreaterIdId",
                table: "Reminder");

            migrationBuilder.RenameColumn(
                name: "UserReminderIdId",
                table: "Reminder",
                newName: "UserReminderId");

            migrationBuilder.RenameColumn(
                name: "UserReminder",
                table: "Reminder",
                newName: "UserCreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserReminderIdId",
                table: "Reminder",
                newName: "IX_Reminder_UserReminderId");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreaterId",
                table: "Reminder",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_UserCreaterId",
                table: "Reminder",
                column: "UserCreaterId");

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
    }
}
