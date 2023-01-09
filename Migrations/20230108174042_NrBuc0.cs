using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farkas_Szabolcs_ProiectExamen.Migrations
{
    public partial class NrBuc0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs");

            migrationBuilder.AlterColumn<int>(
                name: "ProducatorID",
                table: "Produs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "NrBuc",
                table: "Produs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeProducator",
                table: "Producator",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs");

            migrationBuilder.AlterColumn<int>(
                name: "ProducatorID",
                table: "Produs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NrBuc",
                table: "Produs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "NumeProducator",
                table: "Producator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
