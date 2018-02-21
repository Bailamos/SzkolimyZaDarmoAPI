using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Localization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalizationId",
                table: "trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "localizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    voivodeship = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localizations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainings_LocalizationId",
                table: "trainings",
                column: "LocalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_localizations_LocalizationId",
                table: "trainings",
                column: "LocalizationId",
                principalTable: "localizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainings_localizations_LocalizationId",
                table: "trainings");

            migrationBuilder.DropTable(
                name: "localizations");

            migrationBuilder.DropIndex(
                name: "IX_trainings_LocalizationId",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "LocalizationId",
                table: "trainings");
        }
    }
}
