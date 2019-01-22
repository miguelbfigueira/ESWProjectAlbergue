using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class adoptionform4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailReceiver",
                table: "AdoptionForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailReceiverIdId",
                table: "AdoptionForm",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionForm_EmailReceiverIdId",
                table: "AdoptionForm",
                column: "EmailReceiverIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_EmailReceiverIdId",
                table: "AdoptionForm",
                column: "EmailReceiverIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionForm_AspNetUsers_EmailReceiverIdId",
                table: "AdoptionForm");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionForm_EmailReceiverIdId",
                table: "AdoptionForm");

            migrationBuilder.DropColumn(
                name: "EmailReceiver",
                table: "AdoptionForm");

            migrationBuilder.DropColumn(
                name: "EmailReceiverIdId",
                table: "AdoptionForm");
        }
    }
}
