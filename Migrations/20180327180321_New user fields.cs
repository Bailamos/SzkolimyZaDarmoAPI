using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Newuserfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaOfResidenceId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SexId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "hasDisability",
                table: "users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "areas_of_residence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AreaType = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas_of_residence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    EducationType = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notes_users_UserPhoneNumber",
                        column: x => x.UserPhoneNumber,
                        principalTable: "users",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sexes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sexes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_AreaOfResidenceId",
                table: "users",
                column: "AreaOfResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_users_EducationId",
                table: "users",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_users_SexId",
                table: "users",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_notes_UserPhoneNumber",
                table: "notes",
                column: "UserPhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_users_areas_of_residence_AreaOfResidenceId",
                table: "users",
                column: "AreaOfResidenceId",
                principalTable: "areas_of_residence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_educations_EducationId",
                table: "users",
                column: "EducationId",
                principalTable: "educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_sexes_SexId",
                table: "users",
                column: "SexId",
                principalTable: "sexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_areas_of_residence_AreaOfResidenceId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_educations_EducationId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_sexes_SexId",
                table: "users");

            migrationBuilder.DropTable(
                name: "areas_of_residence");

            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "sexes");

            migrationBuilder.DropIndex(
                name: "IX_users_AreaOfResidenceId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_EducationId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_SexId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AreaOfResidenceId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "SexId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "hasDisability",
                table: "users");
        }
    }
}
