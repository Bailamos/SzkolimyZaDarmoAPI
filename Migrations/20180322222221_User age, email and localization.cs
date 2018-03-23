using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Userageemailandlocalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LocalizationId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_LocalizationId",
                table: "users",
                column: "LocalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_localizations_LocalizationId",
                table: "users",
                column: "LocalizationId",
                principalTable: "localizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_localizations_LocalizationId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_LocalizationId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LocalizationId",
                table: "users");
        }
    }
}
