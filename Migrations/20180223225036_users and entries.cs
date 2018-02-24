using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class usersandentries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "entries",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entries", x => new { x.TrainingId, x.UserPhoneNumber });
                    table.ForeignKey(
                        name: "FK_entries_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entries_users_UserPhoneNumber",
                        column: x => x.UserPhoneNumber,
                        principalTable: "users",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entries_UserPhoneNumber",
                table: "entries",
                column: "UserPhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entries");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
