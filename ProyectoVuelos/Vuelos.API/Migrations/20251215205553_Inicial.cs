using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vuelos.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
