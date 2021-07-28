using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Foo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Planet_HomeworldId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Species_Species1Id",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_Species1Id",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planet",
                table: "Planet");

            migrationBuilder.DropColumn(
                name: "Species1Id",
                table: "People");

            migrationBuilder.RenameTable(
                name: "Planet",
                newName: "Planets");

            migrationBuilder.AlterColumn<string>(
                name: "BirthYear",
                table: "People",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Films",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Planets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Diameter",
                table: "Planets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Edited",
                table: "Planets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gravity",
                table: "Planets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Planets",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrbitalPeriod",
                table: "Planets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Population",
                table: "Planets",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RotationPeriod",
                table: "Planets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SurfaceWater",
                table: "Planets",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planets",
                table: "Planets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Climates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Climates_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Terrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terrains_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_PlanetId",
                table: "Films",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_Name",
                table: "Planets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Climates_Name",
                table: "Climates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Climates_PlanetId",
                table: "Climates",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Terrains_Name",
                table: "Terrains",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terrains_PlanetId",
                table: "Terrains",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Planets_PlanetId",
                table: "Films",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Planets_HomeworldId",
                table: "People",
                column: "HomeworldId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Planets_PlanetId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Planets_HomeworldId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Climates");

            migrationBuilder.DropTable(
                name: "Terrains");

            migrationBuilder.DropIndex(
                name: "IX_Films_PlanetId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planets",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_Name",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Edited",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Gravity",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "OrbitalPeriod",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RotationPeriod",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SurfaceWater",
                table: "Planets");

            migrationBuilder.RenameTable(
                name: "Planets",
                newName: "Planet");

            migrationBuilder.AlterColumn<short>(
                name: "BirthYear",
                table: "People",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Species1Id",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planet",
                table: "Planet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_People_Species1Id",
                table: "People",
                column: "Species1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Planet_HomeworldId",
                table: "People",
                column: "HomeworldId",
                principalTable: "Planet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Species_Species1Id",
                table: "People",
                column: "Species1Id",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
