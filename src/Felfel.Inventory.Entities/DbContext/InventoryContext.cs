﻿using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<Batch>().HasData(
                new Batch()
                {
                    BatchId = 1, 
                    DeliveredUnits = 50,                     
                    ExpirationDate = DateTime.Now.AddDays(5), 
                    ProductId = 1, 
                    SupplierName = "Mama Pasta",
                    CreatedAt = DateTime.Now.CreateRandomDate(),
                },
                new Batch()
                {
                    BatchId = 2,
                    DeliveredUnits = 100,                    
                    ExpirationDate = DateTime.Now.AddDays(3),
                    ProductId = 1,
                    SupplierName = "Mama Pasta",
                    CreatedAt = DateTime.Now.CreateRandomDate(),
                });

            modelBuilder.Entity<BatchHistory>().HasData(
                new BatchHistory()
                {
                    BatchHistoryId = 1,
                    BatchId = 1,                    
                    Description = "Order Recived From Supplier Mama Pasta", 
                    Units = 50,
                    CreatedAt = DateTime.Now.CreateRandomDate(),
                },
                new BatchHistory()
                {
                    BatchHistoryId = 2,
                    BatchId = 2,
                    Description = "Order Recived From Supplier Mama Pasta",
                    Units = 100,
                    CreatedAt = DateTime.Now.CreateRandomDate(),
                },
                new BatchHistory()
                {
                    BatchHistoryId = 3,
                    BatchId = 2,
                    Description = "Removed 10 units for Company AAA",
                    Units = -10,
                    CreatedAt = DateTime.Now.CreateRandomDate(),
                });

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
            var day = DateTime.Now.AddDays(d);
            var currentDate = day.AddHours(h).AddMinutes(m).AddSeconds(s);
            //var currentDate = DateTime.Now.AddSeconds(s).AddMinutes(m).AddHours(h).AddDays(d);
            return currentDate;
        }
    }
}