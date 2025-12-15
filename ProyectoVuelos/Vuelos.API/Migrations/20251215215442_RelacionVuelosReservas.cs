using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vuelos.API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionVuelosReservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas");

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 3, 54, 41, 855, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fecha",
                value: new DateTime(2025, 12, 18, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fecha",
                value: new DateTime(2025, 12, 19, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fecha",
                value: new DateTime(2025, 12, 20, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fecha",
                value: new DateTime(2025, 12, 25, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fecha",
                value: new DateTime(2025, 12, 26, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fecha",
                value: new DateTime(2025, 12, 14, 22, 54, 41, 855, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas",
                column: "VueloId",
                principalTable: "Vuelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas");

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 2, 55, 53, 687, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2025, 12, 17, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fecha",
                value: new DateTime(2025, 12, 18, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fecha",
                value: new DateTime(2025, 12, 19, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fecha",
                value: new DateTime(2025, 12, 16, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fecha",
                value: new DateTime(2025, 12, 20, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fecha",
                value: new DateTime(2025, 12, 25, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fecha",
                value: new DateTime(2025, 12, 26, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fecha",
                value: new DateTime(2025, 12, 14, 21, 55, 53, 687, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas",
                column: "VueloId",
                principalTable: "Vuelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
