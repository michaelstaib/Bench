using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class People4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Species1Id",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_Species1Id",
                table: "People",
                column: "Species1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Species_Species1Id",
                table: "People",
                column: "Species1Id",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Species_Species1Id",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_Species1Id",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Species1Id",
                table: "People");
        }
    }
}
