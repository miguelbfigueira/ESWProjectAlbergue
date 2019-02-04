using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_UserId",
                table: "AdoptionForm");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AdoptionForm",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionForm_UserId",
                table: "AdoptionForm",
                newName: "IX_AdoptionForm_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserId",
                table: "AdoptionForm",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserId",
                table: "AdoptionForm");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "AdoptionForm",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionForm_ApplicationUserId",
                table: "AdoptionForm",
                newName: "IX_AdoptionForm_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_UserId",
                table: "AdoptionForm",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
