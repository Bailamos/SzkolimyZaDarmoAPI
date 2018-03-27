using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Counties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "voivodeships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    VoivodeshipName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voivodeships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "counties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CountyName = table.Column<string>(maxLength: 255, nullable: false),
                    VoivodeshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_counties_voivodeships_VoivodeshipId",
                        column: x => x.VoivodeshipId,
                        principalTable: "voivodeships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_CountyId",
                table: "users",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_counties_VoivodeshipId",
                table: "counties",
                column: "VoivodeshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_counties_CountyId",
                table: "users",
                column: "CountyId",
                principalTable: "counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_counties_CountyId",
                table: "users");

            migrationBuilder.DropTable(
                name: "counties");

            migrationBuilder.DropTable(
                name: "voivodeships");

            migrationBuilder.DropIndex(
                name: "IX_users_CountyId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "users");
        }
    }
}
