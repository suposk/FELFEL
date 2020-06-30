using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Felfel.Inventory.Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchHistorys",
                columns: table => new
                {
                    BatchHistoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(nullable: true),
                    BatchId = table.Column<int>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchHistorys", x => x.BatchHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "Batchs",
                columns: table => new
                {
                    BatchId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    DeliveredUnits = table.Column<int>(nullable: false),
                    AvailableUnits = table.Column<int>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.BatchId);
                });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 23, 13, 11, 30, 563, DateTimeKind.Utc).AddTicks(5554), "Order Recived From Supplier Mama Pasta", null, 50 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 23, 13, 11, 30, 563, DateTimeKind.Utc).AddTicks(5621), "Order Recived From Supplier Mama Pasta", null, 100 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 3, 2, new DateTime(2020, 6, 23, 13, 11, 30, 563, DateTimeKind.Utc).AddTicks(5633), "Removed 10 units for Company AAA", null, -10 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId", "SupplierName" },
                values: new object[] { 1, 50, new DateTime(2020, 6, 23, 13, 11, 30, 562, DateTimeKind.Utc).AddTicks(2184), 50, new DateTime(2020, 7, 5, 10, 7, 24, 561, DateTimeKind.Utc).AddTicks(9421), false, null, 1, "Mama Pasta" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId", "SupplierName" },
                values: new object[] { 2, 90, new DateTime(2020, 6, 23, 13, 11, 30, 562, DateTimeKind.Utc).AddTicks(2819), 100, new DateTime(2020, 7, 3, 10, 7, 24, 562, DateTimeKind.Utc).AddTicks(2766), false, null, 1, "Mama Pasta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchHistorys");

            migrationBuilder.DropTable(
                name: "Batchs");
        }
    }
}
