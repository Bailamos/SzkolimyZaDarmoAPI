using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class categoriesandtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE `trainings` DROP FOREIGN KEY `FK_trainings_types_MainTypeName`");

            migrationBuilder.DropTable(
                name: "training_types");

            migrationBuilder.DropTable(
                name: "types");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "training_tag",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    TagName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_tag", x => new { x.TrainingId, x.TagName });
                    table.ForeignKey(
                        name: "FK_training_tag_Tags_TagName",
                        column: x => x.TagName,
                        principalTable: "Tags",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_training_tag_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_training_tag_TagName",
                table: "training_tag",
                column: "TagName");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_categories_MainTypeName",
                table: "trainings",
                column: "MainTypeName",
                principalTable: "categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE `trainings` DROP FOREIGN KEY `FK_trainings_categories_MainTypeName`");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "training_tag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.CreateTable(
                name: "types",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "training_types",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_types", x => new { x.TrainingId, x.TypeName });
                    table.ForeignKey(
                        name: "FK_training_types_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_training_types_types_TypeName",
                        column: x => x.TypeName,
                        principalTable: "types",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_training_types_TypeName",
                table: "training_types",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_types_MainTypeName",
                table: "trainings",
                column: "MainTypeName",
                principalTable: "types",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
