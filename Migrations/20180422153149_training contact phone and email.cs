using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class trainingcontactphoneandemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "trainings",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNumber",
                table: "trainings",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNumber",
                table: "trainings");
        }
    }
}
