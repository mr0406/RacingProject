using Microsoft.EntityFrameworkCore.Migrations;

namespace RacingProject.Server.Migrations
{
    public partial class RacesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Races",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Races",
                newName: "City");
        }
    }
}
