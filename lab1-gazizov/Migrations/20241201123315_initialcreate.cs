using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab1_gazizov.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredStyle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "ExperienceLevel", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Иван Иванов" },
                    { 2, 3, "Петр Петров" },
                    { 3, 5, "Андрей Морозов" },
                    { 4, 3, "Максим Клюев" },
                    { 5, 5, "Виталий Костенко" },
                    { 6, 3, "Семен Даниилов" },
                    { 7, 5, "Артур Манасян" },
                    { 8, 3, "Амир Мурадов" },
                    { 9, 5, "Азамат Халитович" },
                    { 10, 3, "Мимкаел Довлатбекян" },
                    { 11, 5, "Арман Маникян" },
                    { 12, 3, "Андрей Балаян" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PreferredStyle" },
                values: new object[,]
                {
                    { 1, "Алексей Смирнов", "Классический" },
                    { 2, "Дмитрий Винарчук", "Под ноль" },
                    { 3, "Валера Деонтьев", "Тройка" },
                    { 4, "Филипп Киркоров", "Двойка" },
                    { 5, "Вазген Каспарянц", "Под ноль" },
                    { 6, "Ашот Саркисян", "Классический" },
                    { 7, "Рустам Хайруллин", "Классический" },
                    { 8, "Рустам Шайхутдинов", "Модерн" },
                    { 9, "Булат Сидиков", "Тройка" },
                    { 10, "Иван Туманов", "Модерн" },
                    { 11, "Салават Юлаев", "Тройка" },
                    { 12, "Айбек Сулейманов", "Модерн" },
                    { 13, "Булат Шатрашанов", "Двойка" },
                    { 14, "Ильяс Фархутдинов", "Двойка" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 30, "Стрижка", 500m },
                    { 2, 20, "Бритье", 300m },
                    { 3, 40, "Укладка", 400m },
                    { 4, 90, "Окрашивание", 1200m },
                    { 5, 25, "Массаж головы", 700m },
                    { 6, 15, "Мытье головы", 200m },
                    { 7, 60, "Комплекс: стрижка и укладка", 800m },
                    { 8, 20, "Коррекция бороды", 350m },
                    { 9, 25, "Детская стрижка", 400m },
                    { 10, 45, "Камуфлирование седины", 1000m },
                    { 11, 40, "Королевское бритье", 600m },
                    { 12, 10, "Оформление усов", 150m },
                    { 13, 30, "Уход за кожей лица", 500m },
                    { 14, 60, "Тонирование волос", 800m },
                    { 15, 15, "Укладка усов", 200m },
                    { 16, 50, "Комплекс: бритье и массаж головы", 900m },
                    { 17, 20, "Лечебное мытье головы", 300m },
                    { 18, 15, "Стрижка машинкой", 250m },
                    { 19, 25, "Тримминг бороды", 300m },
                    { 20, 45, "Элитное бритье с маслом", 700m }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "BarberId", "CustomerId", "Duration", "ServiceId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 1, 16, 33, 15, 139, DateTimeKind.Local).AddTicks(1082), 1, 1, 0, 1 },
                    { 2, new DateTime(2024, 12, 1, 17, 3, 15, 139, DateTimeKind.Local).AddTicks(1107), 2, 2, 0, 2 },
                    { 3, new DateTime(2024, 12, 1, 17, 33, 15, 139, DateTimeKind.Local).AddTicks(1109), 3, 3, 0, 3 },
                    { 4, new DateTime(2024, 12, 1, 18, 33, 15, 139, DateTimeKind.Local).AddTicks(1110), 4, 4, 0, 4 },
                    { 5, new DateTime(2024, 12, 1, 19, 3, 15, 139, DateTimeKind.Local).AddTicks(1113), 5, 5, 0, 5 },
                    { 6, new DateTime(2024, 12, 1, 19, 33, 15, 139, DateTimeKind.Local).AddTicks(1114), 6, 6, 0, 6 },
                    { 7, new DateTime(2024, 12, 1, 20, 33, 15, 139, DateTimeKind.Local).AddTicks(1115), 7, 7, 0, 7 },
                    { 8, new DateTime(2024, 12, 1, 21, 33, 15, 139, DateTimeKind.Local).AddTicks(1116), 8, 8, 0, 8 },
                    { 9, new DateTime(2024, 12, 1, 22, 3, 15, 139, DateTimeKind.Local).AddTicks(1118), 9, 9, 0, 9 },
                    { 10, new DateTime(2024, 12, 1, 22, 33, 15, 139, DateTimeKind.Local).AddTicks(1119), 10, 10, 0, 10 },
                    { 11, new DateTime(2024, 12, 1, 23, 33, 15, 139, DateTimeKind.Local).AddTicks(1120), 11, 11, 0, 11 },
                    { 12, new DateTime(2024, 12, 2, 0, 33, 15, 139, DateTimeKind.Local).AddTicks(1121), 12, 12, 0, 12 },
                    { 13, new DateTime(2024, 12, 2, 1, 3, 15, 139, DateTimeKind.Local).AddTicks(1123), 1, 13, 0, 13 },
                    { 14, new DateTime(2024, 12, 2, 1, 33, 15, 139, DateTimeKind.Local).AddTicks(1124), 2, 14, 0, 14 },
                    { 15, new DateTime(2024, 12, 2, 2, 33, 15, 139, DateTimeKind.Local).AddTicks(1125), 3, 1, 0, 15 },
                    { 16, new DateTime(2024, 12, 2, 3, 33, 15, 139, DateTimeKind.Local).AddTicks(1126), 4, 2, 0, 16 },
                    { 17, new DateTime(2024, 12, 2, 4, 33, 15, 139, DateTimeKind.Local).AddTicks(1127), 5, 3, 0, 17 },
                    { 18, new DateTime(2024, 12, 2, 5, 3, 15, 139, DateTimeKind.Local).AddTicks(1128), 6, 4, 0, 18 },
                    { 19, new DateTime(2024, 12, 2, 5, 33, 15, 139, DateTimeKind.Local).AddTicks(1130), 7, 5, 0, 19 },
                    { 20, new DateTime(2024, 12, 2, 6, 33, 15, 139, DateTimeKind.Local).AddTicks(1131), 8, 6, 0, 1 },
                    { 21, new DateTime(2024, 12, 2, 7, 33, 15, 139, DateTimeKind.Local).AddTicks(1132), 9, 7, 0, 2 },
                    { 22, new DateTime(2024, 12, 2, 8, 3, 15, 139, DateTimeKind.Local).AddTicks(1133), 10, 8, 0, 3 },
                    { 23, new DateTime(2024, 12, 2, 8, 33, 15, 139, DateTimeKind.Local).AddTicks(1134), 11, 9, 0, 4 },
                    { 24, new DateTime(2024, 12, 2, 9, 33, 15, 139, DateTimeKind.Local).AddTicks(1135), 12, 10, 0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarberId",
                table: "Appointments",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
