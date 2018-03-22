using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Szkolimyzadarmoapi.Migrations
{
    public partial class init_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Email = table.Column<string>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "localizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    voivodeship = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marketStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Status = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminders_instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CategoryName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    LocalizationId = table.Column<int>(nullable: false),
                    MarketStatusId = table.Column<int>(nullable: false),
                    RegisterSince = table.Column<DateTime>(nullable: false),
                    RegisterTo = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainings_categories_CategoryName",
                        column: x => x.CategoryName,
                        principalTable: "categories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainings_instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainings_localizations_LocalizationId",
                        column: x => x.LocalizationId,
                        principalTable: "localizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainings_marketStatuses_MarketStatusId",
                        column: x => x.MarketStatusId,
                        principalTable: "marketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "instructor_roles",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructor_roles", x => new { x.InstructorId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_instructor_roles_instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_instructor_roles_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLog_users_UserPhoneNumber",
                        column: x => x.UserPhoneNumber,
                        principalTable: "users",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entries",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entries", x => new { x.TrainingId, x.UserPhoneNumber });
                    table.ForeignKey(
                        name: "FK_entries_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entries_users_UserPhoneNumber",
                        column: x => x.UserPhoneNumber,
                        principalTable: "users",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_tags",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    TagName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_tags", x => new { x.TrainingId, x.TagName });
                    table.ForeignKey(
                        name: "FK_training_tags_Tags_TagName",
                        column: x => x.TagName,
                        principalTable: "Tags",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_training_tags_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entries_UserPhoneNumber",
                table: "entries",
                column: "UserPhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_instructor_roles_RoleId",
                table: "instructor_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_marketStatuses_Status",
                table: "marketStatuses",
                column: "Status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_InstructorId",
                table: "Reminders",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_training_tags_TagName",
                table: "training_tags",
                column: "TagName");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_CategoryName",
                table: "trainings",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_InstructorId",
                table: "trainings",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_LocalizationId",
                table: "trainings",
                column: "LocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_MarketStatusId",
                table: "trainings",
                column: "MarketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_UserPhoneNumber",
                table: "UserLog",
                column: "UserPhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entries");

            migrationBuilder.DropTable(
                name: "instructor_roles");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "training_tags");

            migrationBuilder.DropTable(
                name: "UserLog");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "trainings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropTable(
                name: "localizations");

            migrationBuilder.DropTable(
                name: "marketStatuses");
        }
    }
}
