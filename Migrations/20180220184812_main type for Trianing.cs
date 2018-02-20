using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class maintypeforTrianing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainTypeName",
                table: "trainings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainings_MainTypeName",
                table: "trainings",
                column: "MainTypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_types_MainTypeName",
                table: "trainings",
                column: "MainTypeName",
                principalTable: "types",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainings_types_MainTypeName",
                table: "trainings");

            migrationBuilder.DropIndex(
                name: "IX_trainings_MainTypeName",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "MainTypeName",
                table: "trainings");
        }
    }
}
