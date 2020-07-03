using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Seguro.Migrations
{
    public partial class DadosCalculoMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "CalculoSeguroVeiculo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "CalculoSeguroVeiculo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Marca_Modelo",
                table: "CalculoSeguroVeiculo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "CalculoSeguroVeiculo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ValorVeiculo",
                table: "CalculoSeguroVeiculo",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "CalculoSeguroVeiculo");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "CalculoSeguroVeiculo");

            migrationBuilder.DropColumn(
                name: "Marca_Modelo",
                table: "CalculoSeguroVeiculo");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "CalculoSeguroVeiculo");

            migrationBuilder.DropColumn(
                name: "ValorVeiculo",
                table: "CalculoSeguroVeiculo");
        }
    }
}
