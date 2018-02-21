using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class marketstatusfkintrainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_trainings_MarketStatusId",
                table: "trainings",
                column: "MarketStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_marketStatuses_MarketStatusId",
                table: "trainings",
                column: "MarketStatusId",
                principalTable: "marketStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainings_marketStatuses_MarketStatusId",
                table: "trainings");

            migrationBuilder.DropIndex(
                name: "IX_trainings_MarketStatusId",
                table: "trainings");
        }
    }
}
