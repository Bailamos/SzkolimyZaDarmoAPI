using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Usercomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_users_marketStatuses_MarketStatusId",
            //     table: "users");
            migrationBuilder.Sql("ALTER TABLE `users` DROP foreign key `FK_users_marketStatuses_MarketStatusId`");

            migrationBuilder.AlterColumn<int>(
                name: "MarketStatusId",
                table: "users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_UserPhoneNumber",
                        column: x => x.UserPhoneNumber,
                        principalTable: "users",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_InstructorId",
                table: "comments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserPhoneNumber",
                table: "comments",
                column: "UserPhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_users_marketStatuses_MarketStatusId",
                table: "users",
                column: "MarketStatusId",
                principalTable: "marketStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_marketStatuses_MarketStatusId",
                table: "users");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "MarketStatusId",
                table: "users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_users_marketStatuses_MarketStatusId",
                table: "users",
                column: "MarketStatusId",
                principalTable: "marketStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
