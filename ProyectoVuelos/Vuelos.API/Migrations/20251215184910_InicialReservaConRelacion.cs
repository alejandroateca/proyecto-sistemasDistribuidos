using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vuelos.API.Migrations
{
    /// <inheritdoc />
    public partial class InicialReservaConRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 0, 49, 10, 311, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fecha",
                value: new DateTime(2025, 12, 18, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fecha",
                value: new DateTime(2025, 12, 19, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fecha",
                value: new DateTime(2025, 12, 20, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fecha",
                value: new DateTime(2025, 12, 25, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fecha",
                value: new DateTime(2025, 12, 26, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fecha",
                value: new DateTime(2025, 12, 14, 19, 49, 10, 311, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas",
                column: "VueloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas",
                column: "VueloId",
                principalTable: "Vuelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas");

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 19, 37, 50, 568, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 0, 37, 50, 569, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fecha",
                value: new DateTime(2025, 12, 18, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fecha",
                value: new DateTime(2025, 12, 19, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fecha",
                value: new DateTime(2025, 12, 20, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fecha",
                value: new DateTime(2025, 12, 25, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fecha",
                value: new DateTime(2025, 12, 26, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fecha",
                value: new DateTime(2025, 12, 14, 19, 37, 50, 569, DateTimeKind.Local).AddTicks(45));
        }
    }
}
