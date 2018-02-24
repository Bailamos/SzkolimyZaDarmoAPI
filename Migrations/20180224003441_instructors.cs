using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class instructors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainings_InstructorId",
                table: "trainings",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_instructors_InstructorId",
                table: "trainings",
                column: "InstructorId",
                principalTable: "instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainings_instructors_InstructorId",
                table: "trainings");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_trainings_InstructorId",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "trainings");
        }
    }
}
