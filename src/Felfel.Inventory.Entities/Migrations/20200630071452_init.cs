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
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
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
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    DeliveredUnits = table.Column<int>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.BatchId);
                });

            migrationBuilder.InsertData(
                table: "BatchHistory",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAt", "Description", "ModifiedAt", "Units" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 23, 12, 18, 57, 987, DateTimeKind.Local).AddTicks(3535), "Order Recived From Supplier Mama Pasta", null, 50 });

            migrationBuilder.InsertData(
                table: "BatchHistory",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAt", "Description", "ModifiedAt", "Units" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 23, 12, 18, 57, 987, DateTimeKind.Local).AddTicks(3605), "Order Recived From Supplier Mama Pasta", null, 100 });

            migrationBuilder.InsertData(
                table: "BatchHistory",
                columns: new[] { "BatchHistoryId", "BatchId", "CreatedAt", "Description", "ModifiedAt", "Units" },
                values: new object[] { 3, 2, new DateTime(2020, 6, 23, 12, 18, 57, 987, DateTimeKind.Local).AddTicks(3621), "Removed 10 units for Company AAA", null, -10 });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "CreatedAt", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAt", "ProductId", "SupplierName" },
                values: new object[] { 1, new DateTime(2020, 6, 23, 12, 18, 57, 985, DateTimeKind.Local).AddTicks(165), 50, new DateTime(2020, 7, 5, 9, 14, 51, 982, DateTimeKind.Local).AddTicks(7297), false, null, 1, "Mama Pasta" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "CreatedAt", "DeliveredUnits", "ExpirationDate", "IsDeleted", "ModifiedAt", "ProductId", "SupplierName" },
                values: new object[] { 2, new DateTime(2020, 6, 23, 12, 18, 57, 985, DateTimeKind.Local).AddTicks(867), 100, new DateTime(2020, 7, 3, 9, 14, 51, 985, DateTimeKind.Local).AddTicks(800), false, null, 1, "Mama Pasta" });
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
