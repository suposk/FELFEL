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
                values: new object[] { 1, 1, new DateTime(2020, 6, 28, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(5968), "Order Recived From Supplier Mama Pasta", null, 50 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 27, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(6035), "Order Recived From Supplier Mama Pasta", null, 100 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 3, 2, new DateTime(2020, 6, 30, 12, 49, 50, 571, DateTimeKind.Utc).AddTicks(6037), "Removed 10 units for Company AAA", null, -10 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 4, 2, new DateTime(2020, 6, 30, 13, 49, 50, 571, DateTimeKind.Utc).AddTicks(6039), "Lost 5 units", null, -5 });

            migrationBuilder.InsertData(
                table: "BatchHistorys",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAtUtc", "Description", "ModifiedAtUtc", "Units" },
                values: new object[] { 5, 3, new DateTime(2020, 6, 30, 13, 49, 50, 571, DateTimeKind.Utc).AddTicks(6040), "Order Recived", null, 200 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAtUtc", "IsActive", "IsDeleted", "ModifiedAtUtc", "Price", "ProductName", "SupplierName" },
                values: new object[] { 1, new DateTime(2020, 6, 23, 17, 53, 56, 570, DateTimeKind.Utc).AddTicks(432), true, false, null, 12.0, "Penne Vodka", "Family Bistro" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAtUtc", "IsActive", "IsDeleted", "ModifiedAtUtc", "Price", "ProductName", "SupplierName" },
                values: new object[] { 2, new DateTime(2020, 6, 23, 17, 53, 56, 570, DateTimeKind.Utc).AddTicks(1163), true, false, null, 8.5, "Cesar Salad", "Family Bistro" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAtUtc", "IsActive", "IsDeleted", "ModifiedAtUtc", "Price", "ProductName", "SupplierName" },
                values: new object[] { 3, new DateTime(2020, 6, 23, 17, 53, 56, 570, DateTimeKind.Utc).AddTicks(1189), true, false, null, 5.5, "Turkey Sandwich", "Jano's Shop" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId" },
                values: new object[] { 1, 50, new DateTime(2020, 6, 28, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(3717), 50, new DateTime(2020, 6, 30, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(2913), false, null, 1 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId" },
                values: new object[] { 2, 85, new DateTime(2020, 6, 27, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(3776), 100, new DateTime(2020, 7, 4, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(3764), false, null, 2 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "AvailableUnits", "CreatedAtUtc", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAtUtc", "ProductId" },
                values: new object[] { 3, 200, new DateTime(2020, 6, 29, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(3808), 200, new DateTime(2020, 6, 28, 14, 49, 50, 571, DateTimeKind.Utc).AddTicks(3807), false, null, 3 });

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
