using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Usercountyoptionalvoivodeshiprequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_users_counties_CountyId",
            //     table: "users");

            migrationBuilder.Sql("ALTER TABLE `users` DROP foreign key `FK_users_counties_CountyId`");

            migrationBuilder.AlterColumn<int>(
                name: "CountyId",
                table: "users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VoivodeshipId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_VoivodeshipId",
                table: "users",
                column: "VoivodeshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_counties_CountyId",
                table: "users",
                column: "CountyId",
                principalTable: "counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_voivodeships_VoivodeshipId",
                table: "users",
                column: "VoivodeshipId",
                principalTable: "voivodeships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_counties_CountyId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_voivodeships_VoivodeshipId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_VoivodeshipId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "VoivodeshipId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "CountyId",
                table: "users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_counties_CountyId",
                table: "users",
                column: "CountyId",
                principalTable: "counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
