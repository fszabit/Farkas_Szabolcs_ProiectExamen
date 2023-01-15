using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farkas_Szabolcs_ProiectExamen.Migrations
{
    public partial class Cumparatori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cumparator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrTel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cumparator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CumparatorID = table.Column<int>(type: "int", nullable: true),
                    ProdusID = table.Column<int>(type: "int", nullable: true),
                    Datarezervarii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervare_Cumparator_CumparatorID",
                        column: x => x.CumparatorID,
                        principalTable: "Cumparator",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rezervare_Produs_ProdusID",
                        column: x => x.ProdusID,
                        principalTable: "Produs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_CumparatorID",
                table: "Rezervare",
                column: "CumparatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ProdusID",
                table: "Rezervare",
                column: "ProdusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervare");

            migrationBuilder.DropTable(
                name: "Cumparator");
        }
    }
}
