using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farkas_Szabolcs_ProiectExamen.Migrations
{
    public partial class Magazin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MagazinID",
                table: "Produs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeProducator",
                table: "Producator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeCategorie",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Magazin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeMagazin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazin", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_MagazinID",
                table: "Produs",
                column: "MagazinID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Magazin_MagazinID",
                table: "Produs",
                column: "MagazinID",
                principalTable: "Magazin",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Magazin_MagazinID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "Magazin");

            migrationBuilder.DropIndex(
                name: "IX_Produs_MagazinID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "MagazinID",
                table: "Produs");

            migrationBuilder.AlterColumn<string>(
                name: "NumeProducator",
                table: "Producator",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeCategorie",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
