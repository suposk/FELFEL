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
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
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
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_Batchs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 29, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(2489), "Order Recived From Supplier Family Bistro", null, 50 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 28, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(2533), "Order Recived From Supplier Family Bistro", null, 100 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 3, 2, new DateTime(2020, 7, 1, 6, 21, 29, 383, DateTimeKind.Utc).AddTicks(2535), "Removed 10 units for Company AAA", null, -10 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 4, 2, new DateTime(2020, 7, 1, 7, 21, 29, 383, DateTimeKind.Utc).AddTicks(2536), "Lost 5 units", null, -5 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 5, 3, new DateTime(2020, 7, 1, 7, 21, 29, 383, DateTimeKind.Utc).AddTicks(2537), "Order Recived", null, 200 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 6, 4, new DateTime(2020, 6, 28, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(2538), "Order Recived From Supplier Family Bistro", null, 100 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 7, 4, new DateTime(2020, 7, 1, 6, 21, 29, 383, DateTimeKind.Utc).AddTicks(2539), "Removed 40 units for Company BBB", null, -40 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAtUtc", "IsActive", "IsDeleted", "ModifiedAtUtc", "Price", "ProductName", "SupplierName" },
                values: new object[] { 1, new DateTime(2020, 6, 24, 11, 25, 35, 381, DateTimeKind.Utc).AddTicks(7863), true, false, null, 12.0, "Penne Vodka", "Family Bistro" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAtUtc", "IsActive", "IsDeleted", "ModifiedAtUtc", "Price", "ProductName", "SupplierName" },
                values: new object[] { 2, new DateTime(2020, 6, 24, 11, 25, 35, 381, DateTimeKind.Utc).AddTicks(8508), true, false, null, 8.5, "Cesar Salad", "Family Bistro" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAtUtc", "IsActive", "IsDeleted", "ModifiedAtUtc", "Price", "ProductName", "SupplierName" },
                values: new object[] { 3, new DateTime(2020, 6, 24, 11, 25, 35, 381, DateTimeKind.Utc).AddTicks(8535), true, false, null, 5.5, "Turkey Sandwich", "Jano's Shop" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId" },
                values: new object[] { 1, 50, new DateTime(2020, 6, 29, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(423), 50, new DateTime(2020, 7, 1, 8, 21, 29, 382, DateTimeKind.Utc).AddTicks(9677), false, null, 1 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId" },
                values: new object[] { 2, 85, new DateTime(2020, 6, 28, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(478), 100, new DateTime(2020, 7, 5, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(467), false, null, 2 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId" },
                values: new object[] { 4, 60, new DateTime(2020, 6, 28, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(483), 100, new DateTime(2020, 7, 1, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(482), false, null, 2 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId" },
                values: new object[] { 3, 200, new DateTime(2020, 6, 28, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(481), 200, new DateTime(2020, 6, 30, 8, 21, 29, 383, DateTimeKind.Utc).AddTicks(480), false, null, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_ProductId",
                table: "Batchs",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchHistorys");

            migrationBuilder.DropTable(
                name: "Batchs");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
