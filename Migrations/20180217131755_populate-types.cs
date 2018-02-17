using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class populatetypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('example type 1')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('example type 2')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('example type 3')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM types WHERE Name IN ('example type 1','example type 2,'example type 3')");
        }
    }
}
