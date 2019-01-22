using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class adoptionform2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserId1",
                table: "AdoptionForm");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionForm_ApplicationUserId1",
                table: "AdoptionForm");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "AdoptionForm");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "AdoptionForm",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionForm_ApplicationUserId",
                table: "AdoptionForm",
                column: "ApplicationUserId");

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

            migrationBuilder.DropIndex(
                name: "IX_AdoptionForm_ApplicationUserId",
                table: "AdoptionForm");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "AdoptionForm",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "AdoptionForm",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionForm_ApplicationUserId1",
                table: "AdoptionForm",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_ApplicationUserId1",
                table: "AdoptionForm",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
