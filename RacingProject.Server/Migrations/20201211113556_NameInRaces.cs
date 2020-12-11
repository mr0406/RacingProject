using Microsoft.EntityFrameworkCore.Migrations;

namespace RacingProject.Server.Migrations
{
    public partial class NameInRaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Races",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Races",
                newName: "Country");
        }
    }
}
