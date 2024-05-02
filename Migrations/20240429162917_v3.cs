using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelasPreco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrecoPorHora = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorHoraAdicional = table.Column<decimal>(type: "TEXT", nullable: false),
                    MinutoTolerancia = table.Column<int>(type: "INTEGER", nullable: false),
                    InicioVigencia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinalVigencia = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelasPreco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    HorarioChegada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HorarioSaida = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Duracao = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    TempoCobrado = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelasPreco");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
