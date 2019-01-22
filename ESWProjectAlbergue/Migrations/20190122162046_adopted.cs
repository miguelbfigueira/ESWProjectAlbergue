using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class adopted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_AnimalBreed_BreedId",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Animal",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BreedId",
                table: "Animal",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Adopted",
                table: "Animal",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_AnimalBreed_BreedId",
                table: "Animal",
                column: "BreedId",
                principalTable: "AnimalBreed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_AnimalBreed_BreedId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Adopted",
                table: "Animal");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Animal",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BreedId",
                table: "Animal",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimalId = table.Column<int>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(maxLength: 100, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_File_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_AnimalId",
                table: "File",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_AnimalBreed_BreedId",
                table: "Animal",
                column: "BreedId",
                principalTable: "AnimalBreed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
