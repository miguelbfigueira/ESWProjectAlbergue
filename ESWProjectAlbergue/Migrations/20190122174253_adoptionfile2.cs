using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class adoptionfile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AdoptionFile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "AdoptionFile");
        }
    }
}
