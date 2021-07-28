using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class People2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Mass",
                table: "People",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "People",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<short>(
                name: "BirthYear",
                table: "People",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Mass",
                table: "People",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "BirthYear",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
