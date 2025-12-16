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
                    table.ForeignKey(
                        name: "FK_Reservas_Vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelos",
                        principalColumn: "Id",
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
                    { 1, true, 120, 150, "BCN", new DateTime(2025, 12, 17, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4546), "08:00", "MAD", 55m },
                    { 2, true, 40, 150, "MAD", new DateTime(2025, 12, 18, 4, 56, 30, 514, DateTimeKind.Local).AddTicks(4591), "13:00", "BCN", 60m },
                    { 3, true, 299, 300, "JFK", new DateTime(2025, 12, 18, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4594), "10:30", "MAD", 450m },
                    { 4, true, 150, 300, "LHR", new DateTime(2025, 12, 19, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4596), "18:00", "JFK", 380m },
                    { 5, true, 300, 300, "JFK", new DateTime(2025, 12, 20, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4598), "09:15", "LHR", 410m },
                    { 6, true, 10, 180, "MAD", new DateTime(2025, 12, 17, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4600), "07:45", "CDG", 90m },
                    { 7, true, 90, 180, "LHR", new DateTime(2025, 12, 21, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4602), "16:20", "MAD", 120m },
                    { 8, true, 200, 400, "HND", new DateTime(2025, 12, 26, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4604), "02:00", "DXB", 850m },
                    { 9, true, 50, 350, "SYD", new DateTime(2025, 12, 27, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4606), "22:30", "HND", 700m },
                    { 10, false, 0, 100, "JFK", new DateTime(2025, 12, 15, 23, 56, 30, 514, DateTimeKind.Local).AddTicks(4608), "12:00", "MAD", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas",
                column: "VueloId");

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
