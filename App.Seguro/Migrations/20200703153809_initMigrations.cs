using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Seguro.Migrations
{
    public partial class initMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculoSeguroVeiculo",
                columns: table => new
                {
                    IdCalculo = table.Column<Guid>(nullable: false),
                    Margem = table.Column<double>(nullable: false),
                    Lucro = table.Column<double>(nullable: false),
                    TaxaRisco = table.Column<double>(nullable: false),
                    PremioPuro = table.Column<double>(nullable: false),
                    PremioComercial = table.Column<double>(nullable: false),
                    DataCalculo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculoSeguroVeiculo", x => x.IdCalculo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculoSeguroVeiculo");
        }
    }
}
