using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_AspNetUsers_UserToVisitIdId",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "UserToVisitIdId",
                table: "Visit",
                newName: "UserToVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_UserToVisitIdId",
                table: "Visit",
                newName: "IX_Visit_UserToVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_AspNetUsers_UserToVisitId",
                table: "Visit",
                column: "UserToVisitId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_AspNetUsers_UserToVisitId",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "UserToVisitId",
                table: "Visit",
                newName: "UserToVisitIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_UserToVisitId",
                table: "Visit",
                newName: "IX_Visit_UserToVisitIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_AspNetUsers_UserToVisitIdId",
                table: "Visit",
                column: "UserToVisitIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
