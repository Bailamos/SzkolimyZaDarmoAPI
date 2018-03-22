using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class populate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO localizations (voivodeship) VALUES ('Pomorskie')");
            migrationBuilder.Sql("INSERT INTO localizations (voivodeship) VALUES ('Mazowieckie')");
            migrationBuilder.Sql("INSERT INTO localizations (voivodeship) VALUES ('Lubelskie')");

            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Bezrobotny')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Aktywny')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Wszystkie')");

            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Jezyki')");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Inne')");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Mechanika')");

            migrationBuilder.Sql("INSERT INTO tags (name) VALUES ('Przyspieszony')");
            migrationBuilder.Sql("INSERT INTO tags (name) VALUES ('Native speaker')");
            migrationBuilder.Sql("INSERT INTO tags (name) VALUES ('Hiszpanski')");

            migrationBuilder.Sql("INSERT INTO roles (roleName) VALUES ('Admin')");
            migrationBuilder.Sql("INSERT INTO roles (roleName) VALUES ('Basic')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM localizations WHERE voivodeship IN ('Pomorskie','Mazowieckie,'Lubelskie')");
            migrationBuilder.Sql("DELETE FROM marketstatuses WHERE status IN ('Bezrobotny','Aktywny','Wszystkie')");
            migrationBuilder.Sql("DELETE FROM categories WHERE name IN ('Mechaniczny','Inny','Angielski')");
            migrationBuilder.Sql("DELETE FROM tags WHERE name IN ('Hiszpanski','speaker','Przyspieszony')");
            migrationBuilder.Sql("DELETE FROM roles WHERE roleName IN ('Admin','Basic')");
        }
    }
}
