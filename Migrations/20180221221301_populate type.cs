using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class populatetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM types WHERE name IN ('example type 1','example type 2','example type 3')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Informatyka')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Motoryzacja')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Jezyki')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Biznes')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Inne')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM types WHERE name IN ('Informatyka','Motoryzacja,'Jezyki','Biznes','Innne')");
        }
    }
}
