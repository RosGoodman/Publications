using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Publications.DAL.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Persons",
                newName: "Patronymic");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Persons",
                newName: "SecondName");
        }
    }
}
