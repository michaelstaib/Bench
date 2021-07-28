using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class People : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BirthYear = table.Column<short>(type: "INTEGER", nullable: false),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    HairColor = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Mass = table.Column<float>(type: "REAL", nullable: false),
                    SkinColor = table.Column<string>(type: "TEXT", nullable: true),
                    HomeworldId = table.Column<int>(type: "INTEGER", nullable: true),
                    SpeciesId = table.Column<int>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Edited = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Planet_HomeworldId",
                        column: x => x.HomeworldId,
                        principalTable: "Planet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmPerson",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeopleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPerson", x => new { x.FilmsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_FilmPerson_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPerson_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmPerson_PeopleId",
                table: "FilmPerson",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_People_HomeworldId",
                table: "People",
                column: "HomeworldId");

            migrationBuilder.CreateIndex(
                name: "IX_People_SpeciesId",
                table: "People",
                column: "SpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmPerson");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
