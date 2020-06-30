using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Felfel.Inventory.Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchHistory",
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
                    table.PrimaryKey("PK_BatchHistory", x => x.BatchHistoryId);
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
                table: "BatchHistory",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 23, 11, 35, 23, 444, DateTimeKind.Utc).AddTicks(8163), "Order Recived From Supplier Mama Pasta", null, 50 });

            migrationBuilder.InsertData(
                table: "BatchHistory",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 23, 11, 35, 23, 444, DateTimeKind.Utc).AddTicks(8229), "Order Recived From Supplier Mama Pasta", null, 100 });

            migrationBuilder.InsertData(
                table: "BatchHistory",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 3, 2, new DateTime(2020, 6, 23, 11, 35, 23, 444, DateTimeKind.Utc).AddTicks(8242), "Removed 10 units for Company AAA", null, -10 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId", "SupplierName" },
                values: new object[] { 1, 50, new DateTime(2020, 6, 23, 11, 35, 23, 442, DateTimeKind.Utc).AddTicks(5774), 50, new DateTime(2020, 7, 5, 8, 31, 17, 442, DateTimeKind.Utc).AddTicks(3050), false, null, 1, "Mama Pasta" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId", "SupplierName" },
                values: new object[] { 2, 90, new DateTime(2020, 6, 23, 11, 35, 23, 442, DateTimeKind.Utc).AddTicks(6395), 100, new DateTime(2020, 7, 3, 8, 31, 17, 442, DateTimeKind.Utc).AddTicks(6343), false, null, 1, "Mama Pasta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchHistory");

            migrationBuilder.DropTable(
                name: "Batchs");
        }
    }
}
