using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class adoptionform3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionFile_AspNetUsers_ApplicationUserId1",
                table: "AdoptionFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserId",
                table: "AdoptionForm");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AdoptionFile");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "AdoptionForm",
                newName: "ApplicationUserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionForm_ApplicationUserId",
                table: "AdoptionForm",
                newName: "IX_AdoptionForm_ApplicationUserIdId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "AdoptionFile",
                newName: "ApplicationUserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionFile_ApplicationUserId1",
                table: "AdoptionFile",
                newName: "IX_AdoptionFile_ApplicationUserIdId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser",
                table: "AdoptionForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser",
                table: "AdoptionFile",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionFile_AspNetUsers_ApplicationUserIdId",
                table: "AdoptionFile",
                column: "ApplicationUserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserIdId",
                table: "AdoptionForm",
                column: "ApplicationUserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionFile_AspNetUsers_ApplicationUserIdId",
                table: "AdoptionFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserIdId",
                table: "AdoptionForm");

            migrationBuilder.DropColumn(
                name: "ApplicationUser",
                table: "AdoptionForm");

            migrationBuilder.DropColumn(
                name: "ApplicationUser",
                table: "AdoptionFile");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserIdId",
                table: "AdoptionForm",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionForm_ApplicationUserIdId",
                table: "AdoptionForm",
                newName: "IX_AdoptionForm_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserIdId",
                table: "AdoptionFile",
                newName: "ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionFile_ApplicationUserIdId",
                table: "AdoptionFile",
                newName: "IX_AdoptionFile_ApplicationUserId1");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "AdoptionFile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionFile_AspNetUsers_ApplicationUserId1",
                table: "AdoptionFile",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserId",
                table: "AdoptionForm",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
