﻿// <auto-generated />
using System;
using Felfel.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Felfel.Inventory.Entities.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Felfel.Inventory.Entities.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AvailableUnits")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveredUnits")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SupplierName")
                        .HasColumnType("TEXT");

                    b.HasKey("BatchId");

                    b.ToTable("Batchs");

                    b.HasData(
                        new
                        {
                            BatchId = 1,
                            AvailableUnits = 50,
                            CreatedAtUtc = new DateTime(2020, 6, 28, 11, 45, 31, 967, DateTimeKind.Utc).AddTicks(2906),
                            DeliveredUnits = 50,
                            ExpirationDate = new DateTime(2020, 7, 5, 11, 45, 31, 967, DateTimeKind.Utc).AddTicks(1679),
                            IsDeleted = false,
                            ProductId = 1,
                            SupplierName = "Mama Pasta"
                        },
                        new
                        {
                            BatchId = 2,
                            AvailableUnits = 90,
                            CreatedAtUtc = new DateTime(2020, 6, 29, 11, 45, 31, 967, DateTimeKind.Utc).AddTicks(3390),
                            DeliveredUnits = 100,
                            ExpirationDate = new DateTime(2020, 7, 3, 11, 45, 31, 967, DateTimeKind.Utc).AddTicks(3363),
                            IsDeleted = false,
                            ProductId = 1,
                            SupplierName = "Mama Pasta"
                        });
                });

            modelBuilder.Entity("Felfel.Inventory.Entities.BatchHistory", b =>
                {
                    b.Property<int>("BatchHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BatchId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("Units")
                        .HasColumnType("INTEGER");

                    b.HasKey("BatchHistoryId");

                    b.ToTable("BatchHistorys");

                    b.HasData(
                        new
                        {
                            BatchHistoryId = 1,
                            BatchId = 1,
                            CreatedAtUtc = new DateTime(2020, 6, 28, 11, 45, 31, 968, DateTimeKind.Utc).AddTicks(5968),
                            Description = "Order Recived From Supplier Mama Pasta",
                            Units = 50
                        },
                        new
                        {
                            BatchHistoryId = 2,
                            BatchId = 2,
                            CreatedAtUtc = new DateTime(2020, 6, 29, 11, 45, 31, 968, DateTimeKind.Utc).AddTicks(6021),
                            Description = "Order Recived From Supplier Mama Pasta",
                            Units = 100
                        },
                        new
                        {
                            BatchHistoryId = 3,
                            BatchId = 2,
                            CreatedAtUtc = new DateTime(2020, 6, 30, 6, 45, 31, 968, DateTimeKind.Utc).AddTicks(6023),
                            Description = "Removed 10 units for Company AAA",
                            Units = -10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
