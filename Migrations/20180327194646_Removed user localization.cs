using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Removeduserlocalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_users_localizations_LocalizationId",
            //     table: "users");
            migrationBuilder.Sql("ALTER TABLE `users` DROP foreign key `FK_users_localizations_LocalizationId`");

            migrationBuilder.DropIndex(
                name: "IX_users_LocalizationId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LocalizationId",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
