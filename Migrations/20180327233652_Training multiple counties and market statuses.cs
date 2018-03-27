using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Trainingmultiplecountiesandmarketstatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoivodeshipId",
                table: "trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "training_localizations",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    CountyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_localizations", x => new { x.TrainingId, x.CountyId });
                    table.ForeignKey(
                        name: "FK_training_localizations_counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_training_localizations_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_marketstatuses",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    MarketStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_marketstatuses", x => new { x.TrainingId, x.MarketStatusId });
                    table.ForeignKey(
                        name: "FK_training_marketstatuses_marketStatuses_MarketStatusId",
                        column: x => x.MarketStatusId,
                        principalTable: "marketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_training_marketstatuses_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainings_VoivodeshipId",
                table: "trainings",
                column: "VoivodeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_training_localizations_CountyId",
                table: "training_localizations",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_training_marketstatuses_MarketStatusId",
                table: "training_marketstatuses",
                column: "MarketStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_voivodeships_VoivodeshipId",
                table: "trainings",
                column: "VoivodeshipId",
                principalTable: "voivodeships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainings_voivodeships_VoivodeshipId",
                table: "trainings");

            migrationBuilder.DropTable(
                name: "training_localizations");

            migrationBuilder.DropTable(
                name: "training_marketstatuses");

            migrationBuilder.DropIndex(
                name: "IX_trainings_VoivodeshipId",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "VoivodeshipId",
                table: "trainings");
        }
    }
}
