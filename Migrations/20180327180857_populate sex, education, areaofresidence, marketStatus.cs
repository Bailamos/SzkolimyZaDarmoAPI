using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class populatesexeducationareaofresidencemarketStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO sexes (Name) VALUES ('Kobieta')");
            migrationBuilder.Sql("INSERT INTO sexes (Name) VALUES ('Meżczyzna')");

            migrationBuilder.Sql("INSERT INTO areas_of_residence (AreaType) VALUES ('Wiejski')");
            migrationBuilder.Sql("INSERT INTO areas_of_residence (AreaType) VALUES ('Miejski')");
            migrationBuilder.Sql("INSERT INTO areas_of_residence (AreaType) VALUES ('Wiejsko-Miejski')");

            migrationBuilder.Sql("INSERT INTO educations (EducationType) VALUES ('Podstawowe')");
            migrationBuilder.Sql("INSERT INTO educations (EducationType) VALUES ('Gimnazjalne')");
            migrationBuilder.Sql("INSERT INTO educations (EducationType) VALUES ('Zasadnicze zawodowe')");
            migrationBuilder.Sql("INSERT INTO educations (EducationType) VALUES ('Ponadgimnazjalne (średnie)')");
            migrationBuilder.Sql("INSERT INTO educations (EducationType) VALUES ('Policealne (np. studium)')");
            migrationBuilder.Sql("INSERT INTO educations (EducationType) VALUES ('Wyższe')");

            migrationBuilder.Sql("DELETE FROM marketstatuses WHERE status IN ('Bezrobotny','Aktywny','Wszystkie')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Pracujący')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Bierny zawodowo')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Inne')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Emeryt')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Uczący się')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Bezrobotny–niepracujący zarejestrowany w PUP')");
            migrationBuilder.Sql("INSERT INTO marketstatuses (status) VALUES ('Niepracujący niezarejestrowany w PUP')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM sexes WHERE Name IN ('Kobieta','Meżczyzna')");
            migrationBuilder.Sql("DELETE FROM educations WHERE EducationType IN ('Podstawowe','Gimnazjalne','Zasadnicze zawodowe','Ponadgimnazjalne (średnie)','Policealne (np. studium)','Wyższe')");
            migrationBuilder.Sql("DELETE FROM areas_of_residence WHERE AreaType IN ('Wiejski','Miejski','Wiejsko - Miejski')");
            migrationBuilder.Sql("DELETE FROM marketstatuses WHERE status IN ('Pracujący','Bierny zawodowo','Inne','Emeryt','Uczący się','Bezrobotny – niepracujący zarejestrowany w PUP','Niepracujący niezarejestrowany w PUP')");
        }
    }
}
