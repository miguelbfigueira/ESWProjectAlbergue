using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESWProjectAlbergue.Migrations
{
    public partial class Animals5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "AAgeType",
                columns: table => new
                {
                    AAgeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAgeType", x => x.AAgeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ABehaviorType",
                columns: table => new
                {
                    ABehaviorTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABehaviorType", x => x.ABehaviorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ABreed",
                columns: table => new
                {
                    ABreedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABreed", x => x.ABreedId);
                });

            migrationBuilder.CreateTable(
                name: "AFurType",
                columns: table => new
                {
                    AFurTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AFurType", x => x.AFurTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AGender",
                columns: table => new
                {
                    AGenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGender", x => x.AGenderId);
                });

            migrationBuilder.CreateTable(
                name: "ASize",
                columns: table => new
                {
                    ASizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASize", x => x.ASizeId);
                });

            migrationBuilder.CreateTable(
                name: "AType",
                columns: table => new
                {
                    ATypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AType", x => x.ATypeId);
                });

            migrationBuilder.CreateTable(
                name: "MainAnimal",
                columns: table => new
                {
                    MainAnimalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AnimalTypeId = table.Column<int>(nullable: false),
                    GenderTypeId = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AnimalAgeTypeId = table.Column<int>(nullable: false),
                    AnimalBreedId = table.Column<int>(nullable: false),
                    AnimalSizeId = table.Column<int>(nullable: false),
                    AnimalFurTypeId = table.Column<int>(nullable: false),
                    AnimalBehaviorTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Adopted = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAnimal", x => x.MainAnimalId);
                    table.ForeignKey(
                        name: "FK_MainAnimal_AAgeType_AnimalAgeTypeId",
                        column: x => x.AnimalAgeTypeId,
                        principalTable: "AAgeType",
                        principalColumn: "AAgeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainAnimal_ABehaviorType_AnimalBehaviorTypeId",
                        column: x => x.AnimalBehaviorTypeId,
                        principalTable: "ABehaviorType",
                        principalColumn: "ABehaviorTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainAnimal_ABreed_AnimalBreedId",
                        column: x => x.AnimalBreedId,
                        principalTable: "ABreed",
                        principalColumn: "ABreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainAnimal_AFurType_AnimalFurTypeId",
                        column: x => x.AnimalFurTypeId,
                        principalTable: "AFurType",
                        principalColumn: "AFurTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainAnimal_ASize_AnimalSizeId",
                        column: x => x.AnimalSizeId,
                        principalTable: "ASize",
                        principalColumn: "ASizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainAnimal_AType_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AType",
                        principalColumn: "ATypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainAnimal_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainAnimal_AGender_GenderTypeId",
                        column: x => x.GenderTypeId,
                        principalTable: "AGender",
                        principalColumn: "AGenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_AnimalAgeTypeId",
                table: "MainAnimal",
                column: "AnimalAgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_AnimalBehaviorTypeId",
                table: "MainAnimal",
                column: "AnimalBehaviorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_AnimalBreedId",
                table: "MainAnimal",
                column: "AnimalBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_AnimalFurTypeId",
                table: "MainAnimal",
                column: "AnimalFurTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_AnimalSizeId",
                table: "MainAnimal",
                column: "AnimalSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_AnimalTypeId",
                table: "MainAnimal",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_ApplicationUserId1",
                table: "MainAnimal",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MainAnimal_GenderTypeId",
                table: "MainAnimal",
                column: "GenderTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainAnimal");

            migrationBuilder.DropTable(
                name: "AAgeType");

            migrationBuilder.DropTable(
                name: "ABehaviorType");

            migrationBuilder.DropTable(
                name: "ABreed");

            migrationBuilder.DropTable(
                name: "AFurType");

            migrationBuilder.DropTable(
                name: "ASize");

            migrationBuilder.DropTable(
                name: "AType");

            migrationBuilder.DropTable(
                name: "AGender");

            migrationBuilder.CreateTable(
                name: "AnimalAgeType",
                columns: table => new
                {
                    AnimalAgeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalAgeType", x => x.AnimalAgeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AnimalBehaviorType",
                columns: table => new
                {
                    AnimalBehaviorTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalBehaviorType", x => x.AnimalBehaviorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AnimalBreed",
                columns: table => new
                {
                    AnimalBreedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalBreed", x => x.AnimalBreedId);
                });

            migrationBuilder.CreateTable(
                name: "AnimalFurType",
                columns: table => new
                {
                    AnimalFurTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFurType", x => x.AnimalFurTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AnimalGenderType",
                columns: table => new
                {
                    AnimalGenderTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalGenderType", x => x.AnimalGenderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AnimalSize",
                columns: table => new
                {
                    AnimalSizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSize", x => x.AnimalSizeId);
                });

            migrationBuilder.CreateTable(
                name: "AnimalType",
                columns: table => new
                {
                    AnimalTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalType", x => x.AnimalTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adopted = table.Column<bool>(nullable: false),
                    AnimalAgeTypeId = table.Column<int>(nullable: false),
                    AnimalBehaviorTypeId = table.Column<int>(nullable: false),
                    AnimalBreedId = table.Column<int>(nullable: false),
                    AnimalFurTypeId = table.Column<int>(nullable: false),
                    AnimalSizeId = table.Column<int>(nullable: false),
                    AnimalTypeId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GenderTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalAgeType_AnimalAgeTypeId",
                        column: x => x.AnimalAgeTypeId,
                        principalTable: "AnimalAgeType",
                        principalColumn: "AnimalAgeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalBehaviorType_AnimalBehaviorTypeId",
                        column: x => x.AnimalBehaviorTypeId,
                        principalTable: "AnimalBehaviorType",
                        principalColumn: "AnimalBehaviorTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalBreed_AnimalBreedId",
                        column: x => x.AnimalBreedId,
                        principalTable: "AnimalBreed",
                        principalColumn: "AnimalBreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalFurType_AnimalFurTypeId",
                        column: x => x.AnimalFurTypeId,
                        principalTable: "AnimalFurType",
                        principalColumn: "AnimalFurTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalSize_AnimalSizeId",
                        column: x => x.AnimalSizeId,
                        principalTable: "AnimalSize",
                        principalColumn: "AnimalSizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalType_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalType",
                        principalColumn: "AnimalTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalGenderType_GenderTypeId",
                        column: x => x.GenderTypeId,
                        principalTable: "AnimalGenderType",
                        principalColumn: "AnimalGenderTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalAgeTypeId",
                table: "Animal",
                column: "AnimalAgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalBehaviorTypeId",
                table: "Animal",
                column: "AnimalBehaviorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalBreedId",
                table: "Animal",
                column: "AnimalBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalFurTypeId",
                table: "Animal",
                column: "AnimalFurTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalSizeId",
                table: "Animal",
                column: "AnimalSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalTypeId",
                table: "Animal",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ApplicationUserId1",
                table: "Animal",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_GenderTypeId",
                table: "Animal",
                column: "GenderTypeId");
        }
    }
}
