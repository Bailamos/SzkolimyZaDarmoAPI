using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Marketstatuspopulate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Bezrobotny')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Aktywny')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Wszystkie')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM marketstatuses WHERE status IN ('Bezrobotny','Aktywny','Wszystkie')");
        }
    }
}
