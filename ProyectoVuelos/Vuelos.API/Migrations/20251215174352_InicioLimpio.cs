using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vuelos.API.Migrations
{
    /// <inheritdoc />
    public partial class InicioLimpio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vuelo",
                table: "Vuelo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aeropuerto",
                table: "Aeropuerto");

            migrationBuilder.RenameTable(
                name: "Vuelo",
                newName: "Vuelos");

            migrationBuilder.RenameTable(
                name: "Reserva",
                newName: "Reservas");

            migrationBuilder.RenameTable(
                name: "Aeropuerto",
                newName: "Aeropuertos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vuelos",
                table: "Vuelos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aeropuertos",
                table: "Aeropuertos",
                column: "Codigo");

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 18, 43, 52, 790, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 18, 43, 52, 790, DateTimeKind.Local).AddTicks(3475));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vuelos",
                table: "Vuelos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aeropuertos",
                table: "Aeropuertos");

            migrationBuilder.RenameTable(
                name: "Vuelos",
                newName: "Vuelo");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "Reserva");

            migrationBuilder.RenameTable(
                name: "Aeropuertos",
                newName: "Aeropuerto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vuelo",
                table: "Vuelo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aeropuerto",
                table: "Aeropuerto",
                column: "Codigo");

            migrationBuilder.UpdateData(
                table: "Vuelo",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 18, 37, 15, 791, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Vuelo",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 18, 37, 15, 791, DateTimeKind.Local).AddTicks(4827));
        }
    }
}
