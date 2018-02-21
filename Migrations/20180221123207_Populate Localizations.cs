using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class PopulateLocalizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO localizations (voivodeship) VALUES ('Pomorskie')");
            migrationBuilder.Sql("INSERT INTO localizations (voivodeship) VALUES ('Mazowieckie')");
            migrationBuilder.Sql("INSERT INTO localizations (voivodeship) VALUES ('Lubelskie')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM localizations WHERE voivodeship IN ('Pomorskie','Mazowieckie,'Lubelskie')");
        }
    }
}
