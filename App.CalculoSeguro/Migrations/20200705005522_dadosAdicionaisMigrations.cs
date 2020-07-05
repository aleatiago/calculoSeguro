using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Seguro.Migrations
{
    public partial class dadosAdicionaisMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca_Modelo",
                table: "CalculoSeguroVeiculo",
                newName: "Veiculo");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "CalculoSeguroVeiculo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "CalculoSeguroVeiculo",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "CalculoSeguroVeiculo");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "CalculoSeguroVeiculo");

            migrationBuilder.RenameColumn(
                name: "Veiculo",
                table: "CalculoSeguroVeiculo",
                newName: "Marca_Modelo");
        }
    }
}
