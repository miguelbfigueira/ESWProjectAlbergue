using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AnimalType = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Breed = table.Column<int>(nullable: false),
                    SizeType = table.Column<int>(nullable: false),
                    FurType = table.Column<int>(nullable: false),
                    AgeType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BehaviorType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Visit",
            //    columns: table => new
            //    {
            //        VisitId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        UserToVisitId = table.Column<string>(nullable: true),
            //        Date = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Visit", x => x.VisitId);
            //        table.ForeignKey(
            //            name: "FK_Visit_AspNetUsers_UserToVisitId",
            //            column: x => x.UserToVisitId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Visit_UserToVisitId",
            //    table: "Visit",
            //    column: "UserToVisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Animal");

            //migrationBuilder.DropTable(
            //    name: "Visit");
        }
    }
}
