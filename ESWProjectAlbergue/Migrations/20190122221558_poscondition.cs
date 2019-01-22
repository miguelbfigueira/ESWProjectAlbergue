using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class poscondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosConditionsForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdoptionFileId = table.Column<int>(nullable: false),
                    Answer1 = table.Column<bool>(nullable: false),
                    Answer2 = table.Column<bool>(nullable: false),
                    Answer3 = table.Column<bool>(nullable: false),
                    result = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosConditionsForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosConditionsForm_AdoptionFile_AdoptionFileId",
                        column: x => x.AdoptionFileId,
                        principalTable: "AdoptionFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosConditionsForm_AdoptionFileId",
                table: "PosConditionsForm",
                column: "AdoptionFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosConditionsForm");
        }
    }
}
