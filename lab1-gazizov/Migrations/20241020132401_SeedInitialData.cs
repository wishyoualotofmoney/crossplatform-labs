using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab1_gazizov.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "BarberId", "CustomerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 20, 17, 23, 59, 870, DateTimeKind.Local).AddTicks(9713), 1, 1 },
                    { 2, new DateTime(2024, 10, 20, 19, 23, 59, 870, DateTimeKind.Local).AddTicks(9749), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "ExperienceLevel", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Иван Иванов" },
                    { 2, 3, "Петр Петров" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PreferredStyle" },
                values: new object[,]
                {
                    { 1, "Алексей Смирнов", "Классический" },
                    { 2, "Мария Сидорова", "Модерн" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
