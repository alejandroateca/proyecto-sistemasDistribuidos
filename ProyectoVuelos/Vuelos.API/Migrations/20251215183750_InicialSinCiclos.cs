using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vuelos.API.Migrations
{
    /// <inheritdoc />
    public partial class InicialSinCiclos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuertos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuertos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
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
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigenCodigo = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    DestinoCodigo = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AsientosTotales = table.Column<int>(type: "int", nullable: false),
                    AsientosOcupados = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aeropuertos_DestinoCodigo",
                        column: x => x.DestinoCodigo,
                        principalTable: "Aeropuertos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aeropuertos_OrigenCodigo",
                        column: x => x.OrigenCodigo,
                        principalTable: "Aeropuertos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Aeropuertos",
                columns: new[] { "Codigo", "Ciudad", "Nombre" },
                values: new object[,]
                {
                    { "BCN", "Barcelona", "El Prat" },
                    { "CDG", "París", "Charles de Gaulle" },
                    { "DXB", "Dubai", "Dubai Intl" },
                    { "HND", "Tokio", "Haneda" },
                    { "JFK", "New York", "John F. Kennedy" },
                    { "LHR", "Londres", "Heathrow" },
                    { "MAD", "Madrid", "Adolfo Suárez" },
                    { "SYD", "Sydney", "Kingsford Smith" }
                });

            migrationBuilder.InsertData(
                table: "Vuelos",
                columns: new[] { "Id", "Activo", "AsientosOcupados", "AsientosTotales", "DestinoCodigo", "Fecha", "Hora", "OrigenCodigo", "Precio" },
                values: new object[,]
                {
                    { 1, true, 120, 150, "BCN", new DateTime(2025, 12, 16, 19, 37, 50, 568, DateTimeKind.Local).AddTicks(9978), "08:00", "MAD", 55m },
                    { 2, true, 40, 150, "MAD", new DateTime(2025, 12, 17, 0, 37, 50, 569, DateTimeKind.Local).AddTicks(25), "13:00", "BCN", 60m },
                    { 3, true, 299, 300, "JFK", new DateTime(2025, 12, 17, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(28), "10:30", "MAD", 450m },
                    { 4, true, 150, 300, "LHR", new DateTime(2025, 12, 18, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(30), "18:00", "JFK", 380m },
                    { 5, true, 300, 300, "JFK", new DateTime(2025, 12, 19, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(32), "09:15", "LHR", 410m },
                    { 6, true, 10, 180, "MAD", new DateTime(2025, 12, 16, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(37), "07:45", "CDG", 90m },
                    { 7, true, 90, 180, "LHR", new DateTime(2025, 12, 20, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(39), "16:20", "MAD", 120m },
                    { 8, true, 200, 400, "HND", new DateTime(2025, 12, 25, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(41), "02:00", "DXB", 850m },
                    { 9, true, 50, 350, "SYD", new DateTime(2025, 12, 26, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(43), "22:30", "HND", 700m },
                    { 10, false, 0, 100, "JFK", new DateTime(2025, 12, 14, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(45), "12:00", "MAD", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_DestinoCodigo",
                table: "Vuelos",
                column: "DestinoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_OrigenCodigo",
                table: "Vuelos",
                column: "OrigenCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Aeropuertos");
        }
    }
}
