using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vuelos.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuerto", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VueloId = table.Column<int>(type: "int", nullable: false),
                    NombrePasajero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AsientosReservados = table.Column<int>(type: "int", nullable: false),
                    ImportePagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AsientosTotales = table.Column<int>(type: "int", nullable: false),
                    AsientosOcupados = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aeropuerto",
                columns: new[] { "Codigo", "Ciudad", "Nombre" },
                values: new object[,]
                {
                    { "BCN", "Barcelona", "El Prat" },
                    { "JFK", "New York", "JFK Intl" },
                    { "MAD", "Madrid", "Barajas" }
                });

            migrationBuilder.InsertData(
                table: "Vuelo",
                columns: new[] { "Id", "AsientosOcupados", "AsientosTotales", "Destino", "Fecha", "Hora", "Origen", "Precio" },
                values: new object[,]
                {
                    { 1, 10, 100, "BCN", new DateTime(2025, 12, 16, 18, 37, 15, 791, DateTimeKind.Local).AddTicks(4780), "", "MAD", 50m },
                    { 2, 199, 200, "JFK", new DateTime(2025, 12, 17, 18, 37, 15, 791, DateTimeKind.Local).AddTicks(4827), "", "MAD", 450m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeropuerto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
