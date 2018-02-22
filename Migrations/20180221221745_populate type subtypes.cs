using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class populatetypesubtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Angielski')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Native speaker')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Przyspieszony')");
            migrationBuilder.Sql("INSERT INTO types (name) VALUES ('Elastyczne godziny')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM types WHERE name IN ('Angielski','Native speaker,'Przyspieszony','Elastyczne godziny')");
        }
    }
}
