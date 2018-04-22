using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class UserbirthYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                table: "users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "users");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
