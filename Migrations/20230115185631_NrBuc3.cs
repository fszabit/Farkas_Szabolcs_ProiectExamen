using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farkas_Szabolcs_ProiectExamen.Migrations
{
    public partial class NrBuc3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ProdusNrBuc",
                table: "Rezervare",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProdusNrBuc",
                table: "Rezervare",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
