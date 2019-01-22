using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class adoptionform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdoptionForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimalId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Cc = table.Column<int>(nullable: false),
                    Job = table.Column<string>(nullable: true),
                    MoreAnimals = table.Column<bool>(nullable: false),
                    HowMany = table.Column<string>(nullable: true),
                    AnimalTypes = table.Column<string>(nullable: true),
                    FinanciallyStable = table.Column<bool>(nullable: false),
                    HouseType = table.Column<int>(nullable: false),
                    NumberOfBedrooms = table.Column<int>(nullable: false),
                    NumberOfPeople = table.Column<int>(nullable: false),
                    AnimalTravel = table.Column<string>(nullable: true),
                    LeaveHouse = table.Column<int>(nullable: false),
                    Conscious = table.Column<bool>(nullable: false),
                    TermsAndConditions = table.Column<bool>(nullable: false),
                    Accepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionForm_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdoptionForm_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionForm_AnimalId",
                table: "AdoptionForm",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionForm_ApplicationUserId1",
                table: "AdoptionForm",
                column: "ApplicationUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionForm");
        }
    }
}
