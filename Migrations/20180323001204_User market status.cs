using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Usermarketstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarketStatusId",
                table: "users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_MarketStatusId",
                table: "users",
                column: "MarketStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_marketStatuses_MarketStatusId",
                table: "users",
                column: "MarketStatusId",
                principalTable: "marketStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_marketStatuses_MarketStatusId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_MarketStatusId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "MarketStatusId",
                table: "users");
        }
    }
}
