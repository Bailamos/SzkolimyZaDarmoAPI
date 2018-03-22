using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class Rolespopulate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO roles (roleName) VALUES ('Admin')");
            migrationBuilder.Sql("INSERT INTO roles (roleName) VALUES ('Basic')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM roles WHERE roleName IN ('Admin','Basic')");
        }
    }
}
