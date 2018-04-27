using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class UserLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE userlog CHANGE `Description` `PropertyName` TEXT;");
            // migrationBuilder.RenameColumn(
            //     name: "Description",
            //     table: "UserLog",
            //     newName: "PropertyName");    

            migrationBuilder.Sql("ALTER TABLE userlog CHANGE `Date` `ChangeDate` DATETIME;");
            // migrationBuilder.RenameColumn(
            //     name: "Date",
            //     table: "UserLog",
            //     newName: "ChangeDate");

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "UserLog",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OldValue",
                table: "UserLog",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "UserLog");

            migrationBuilder.DropColumn(
                name: "OldValue",
                table: "UserLog");


            migrationBuilder.Sql("ALTER TABLE userlog CHANGE `PropertyName` `Description` TEXT;");

            migrationBuilder.Sql("ALTER TABLE userlog CHANGE `ChangeDate` `Date` DATETIME;");

        }
    }
}
