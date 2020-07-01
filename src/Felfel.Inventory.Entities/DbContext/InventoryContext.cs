using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Entities
{
    public class InventoryContext : DbContext
    {
        private readonly string _connectionString;

        public InventoryContext() : base()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public InventoryContext(string connectionString) : base()
        {
            _connectionString = connectionString;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public InventoryContext(DbContextOptions<InventoryContext> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Batch> Batchs { get; set; }
        public DbSet<BatchHistory> BatchHistorys { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //sql Lite
                if (!string.IsNullOrWhiteSpace(_connectionString))
                    optionsBuilder.UseSqlite(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1, 
                    ProductName = "Penne Vodka", 
                    SupplierName = "Family Bistro",                      
                    Price = 12,
                    CreatedAtUtc = DateTime.UtcNow.CreateRandomDate(),
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Cesar Salad",
                    SupplierName = "Family Bistro",
                    Price = 8.5,
                    CreatedAtUtc = DateTime.UtcNow.CreateRandomDate(),
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Turkey Sandwich",
                    SupplierName = "Jano's Shop",
                    Price = 5.5,
                    CreatedAtUtc = DateTime.UtcNow.CreateRandomDate(),
                });

            modelBuilder.Entity<Batch>().HasData(
                new Batch()
                {
                    BatchId = 1, 
                    DeliveredUnits = 50,
                    AvailableUnits = 50,
                    ExpirationDate = DateTime.UtcNow, 
                    ProductId = 1,                     
                    CreatedAtUtc = DateTime.UtcNow.AddDays(-2),
                },
                new Batch()
                {
                    BatchId = 2,
                    DeliveredUnits = 100,
                    AvailableUnits = 85,
                    ExpirationDate = DateTime.UtcNow.AddDays(4),
                    ProductId = 2,                    
                    CreatedAtUtc = DateTime.UtcNow.AddDays(-3),
                },
                new Batch()
                {
                    BatchId = 3,
                    DeliveredUnits = 200,
                    AvailableUnits = 200,
                    ExpirationDate = DateTime.UtcNow.AddDays(-1),
                    ProductId = 3,
                    CreatedAtUtc = DateTime.UtcNow.AddDays(-3),
                },
                new Batch()
                {
                    BatchId = 4,
                    DeliveredUnits = 100,
                    AvailableUnits = 60,
                    ExpirationDate = DateTime.UtcNow.AddDays(0),
                    ProductId = 2,
                    CreatedAtUtc = DateTime.UtcNow.AddDays(-3),
                });

            modelBuilder.Entity<BatchHistory>().HasData(
                new BatchHistory()
                {
                    BatchHistoryId = 1,
                    BatchId = 1,                    
                    Description = "Order Recived From Supplier Family Bistro", 
                    Units = 50,
                    CreatedAtUtc = DateTime.UtcNow.AddDays(-2),
                },

                new BatchHistory()
                {
                    BatchHistoryId = 2,
                    BatchId = 2,
                    Description = "Order Recived From Supplier Family Bistro",
                    Units = 100,
                    CreatedAtUtc = DateTime.UtcNow.AddDays(-3),
                },
                new BatchHistory()
                {
                    BatchHistoryId = 3,
                    BatchId = 2,
                    Description = "Removed 10 units for Company AAA",
                    Units = -10,
                    CreatedAtUtc = DateTime.UtcNow.AddHours(-2),
                },
                new BatchHistory()
                {
                    BatchHistoryId = 4,
                    BatchId = 2,
                    Description = "Lost 5 units",
                    Units = -5,
                    CreatedAtUtc = DateTime.UtcNow.AddHours(-1),
                },

                new BatchHistory()
                {
                    BatchHistoryId = 5,
                    BatchId = 3,
                    Description = "Order Recived",
                    Units = 200,
                    CreatedAtUtc = DateTime.UtcNow.AddHours(-1),
                },

                new BatchHistory()
                {
                    BatchHistoryId = 6,
                    BatchId = 4,
                    Description = "Order Recived From Supplier Family Bistro",
                    Units = 100,
                    CreatedAtUtc = DateTime.UtcNow.AddDays(-3),
                },
                new BatchHistory()
                {
                    BatchHistoryId = 7,
                    BatchId = 4,
                    Description = "Removed 40 units for Company BBB",
                    Units = -40,
                    CreatedAtUtc = DateTime.UtcNow.AddHours(-2),
                }

                );

        }
    }

    public static class DateTimeHelper
    {
        public static DateTime CreateRandomDate(this DateTime dateTime)
        {
            Random random = new Random(20);
            int _min = -10;
            int _max = 10;

            var d = random.Next(_min, _max);
            var h = random.Next(_min, _max);
            var m = random.Next(_min, _max);
            var s = random.Next(_min, _max);
            var day = DateTime.UtcNow.AddDays(d);
            var currentDate = day.AddHours(h).AddMinutes(m).AddSeconds(s);
            //var currentDate = DateTime.UtcNow.AddSeconds(s).AddMinutes(m).AddHours(h).AddDays(d);
            return currentDate;
        }
    }
}
