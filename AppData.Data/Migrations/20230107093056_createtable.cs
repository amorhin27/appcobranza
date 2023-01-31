using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Data.Migrations
{
    public partial class createtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Personas",
                newName: "PeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeopleId",
                table: "Personas",
                newName: "PersonaId");
        }
    }
}
