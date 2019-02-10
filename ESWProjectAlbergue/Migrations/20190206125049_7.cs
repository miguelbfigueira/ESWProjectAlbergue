using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerfectAnimal",
                columns: table => new
                {
                    PerfectAnimalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BreedId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfectAnimal", x => x.PerfectAnimalId);
                    table.ForeignKey(
                        name: "FK_PerfectAnimal_AnimalBreed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "AnimalBreed",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfectAnimal_BreedId",
                table: "PerfectAnimal",
                column: "BreedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfectAnimal");
        }
    }
}
