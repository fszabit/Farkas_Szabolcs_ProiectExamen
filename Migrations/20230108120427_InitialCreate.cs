using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farkas_Szabolcs_ProiectExamen.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    NrBuc = table.Column<long>(type: "bigint", nullable: true),
                    Valabilitate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
