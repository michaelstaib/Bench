using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EpisodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    DirectorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Edited = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmProducer",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProducersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmProducer", x => new { x.FilmsId, x.ProducersId });
                    table.ForeignKey(
                        name: "FK_FilmProducer_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmProducer_Producers_ProducersId",
                        column: x => x.ProducersId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_Name",
                table: "Directors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmProducer_ProducersId",
                table: "FilmProducer",
                column: "ProducersId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_EpisodeId",
                table: "Films",
                column: "EpisodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_Title",
                table: "Films",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producers_Name",
                table: "Producers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmProducer");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
