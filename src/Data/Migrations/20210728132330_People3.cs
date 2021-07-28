using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class People3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_Name",
                table: "People",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_Name",
                table: "People");
        }
    }
}
