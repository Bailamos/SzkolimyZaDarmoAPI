using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class addedMarketStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterTo",
                table: "trainings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterSince",
                table: "trainings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarketStatusId",
                table: "trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "trainings",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "marketStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Status = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_marketStatuses_Status",
                table: "marketStatuses",
                column: "Status",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marketStatuses");

            migrationBuilder.DropColumn(
                name: "MarketStatusId",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "trainings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterTo",
                table: "trainings",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterSince",
                table: "trainings",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
