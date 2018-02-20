using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Newtrianingcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterSince",
                table: "trainings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterTo",
                table: "trainings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterSince",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "RegisterTo",
                table: "trainings");
        }
    }
}
