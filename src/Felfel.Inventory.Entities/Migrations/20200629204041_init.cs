using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Felfel.Inventory.Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DeliveredQuantity = table.Column<int>(nullable: false),
                    CurrentQuantity = table.Column<int>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.BatchId);
                });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "CreatedAt", "CurrentQuantity", "DeliveredQuantity", "ExpirationDate", "IsDeleted", "ModifiedAt", "ProductId", "SupplierName" },
                values: new object[] { 1, new DateTime(2020, 6, 23, 1, 44, 46, 967, DateTimeKind.Local).AddTicks(9937), 50, 50, new DateTime(2020, 7, 4, 22, 40, 40, 966, DateTimeKind.Local).AddTicks(1812), false, null, 1, "Mama Pasta" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "BatchId", "CreatedAt", "CurrentQuantity", "DeliveredQuantity", "ExpirationDate", "IsDeleted", "ModifiedAt", "ProductId", "SupplierName" },
                values: new object[] { 2, new DateTime(2020, 6, 23, 1, 44, 46, 968, DateTimeKind.Local).AddTicks(662), 100, 100, new DateTime(2020, 7, 2, 22, 40, 40, 968, DateTimeKind.Local).AddTicks(515), false, null, 1, "Mama Pasta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batchs");
        }
    }
}
