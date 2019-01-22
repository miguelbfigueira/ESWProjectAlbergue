using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class adoptionfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdoptionFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimalId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionFile_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdoptionFile_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionFile_AnimalId",
                table: "AdoptionFile",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionFile_ApplicationUserId1",
                table: "AdoptionFile",
                column: "ApplicationUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionFile");
        }
    }
}
