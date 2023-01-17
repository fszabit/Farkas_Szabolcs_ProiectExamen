using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farkas_Szabolcs_ProiectExamen.Migrations
{
    public partial class NrBuc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdusNrBuc",
                table: "Rezervare",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdusNrBuc",
                table: "Rezervare");
        }
    }
}
