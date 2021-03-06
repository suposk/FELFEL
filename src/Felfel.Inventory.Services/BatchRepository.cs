﻿using Felfel.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace Felfel.Inventory.Services
{

    public class BatchRepository : GenericRepository, IBatchRepository
    {
        public BatchRepository(InventoryContext context) : base(context)
        {

        }

        public Task<List<Batch>> GetFilter(Expression<Func<Batch, bool>> expression)
        {
            return Context.Batchs.Include(a => a.Product).Where(expression).ToListAsync();
        }

        public Task<Batch> GetById(int Id)
        {
            return Context.Batchs.Include(a => a.Product)
                .FirstOrDefaultAsync(a => a.BatchId == Id);            
        }

        public Task<int> GetAvailableUnits(int Id)
        {
            return Context.BatchHistorys.Where(a =>a.BatchId == Id).SumAsync(a => a.Units);
        }


        public async Task<bool> AddBatch(Batch batch)
        {            
            if (batch == null)
                throw new ArgumentNullException(nameof(batch));

            BatchHistory history;
            base.AddGeneric(batch);
            if (await SaveChangesAsync() && batch.BatchId > 0)
            {
                history = new BatchHistory
                {
                    BatchId = batch.BatchId,
                    Units = batch.DeliveredUnits,
                    Description = $"Order of {batch.DeliveredUnits} units delivered"
                };
                base.AddGeneric(history);
                if (await SaveChangesAsync() && history.BatchHistoryId > 0)
                {
                    return true;
                }
                else
                {
                    base.DeleteGeneric(batch);
                    return await SaveChangesAsync();
                }
            }
            else            
                return false;            
        }

        public async Task<Batch> UpdateUnits(int Id, int units, string description, bool decrementCount)
        {
            var toUpdateTask = GetById(Id);
            var historySumTask = GetAvailableUnits(Id);

            await Task.WhenAll(new List<Task> { toUpdateTask, historySumTask });

            var existingCount = toUpdateTask.Result.AvailableUnits;
            if (historySumTask.Result != existingCount)
                throw new Exception("Data Incositate State");


            if (decrementCount)
            {                
                if (existingCount < units)                
                    throw new ArgumentException("Not enoght available units.");
                
                units = units * -1;
            }
            else
            {
                if (existingCount + units > toUpdateTask.Result.DeliveredUnits)
                    throw new ArgumentException("Number of units exides original delivered units.");
            }

            if (string.IsNullOrWhiteSpace(description))
                description = $"{(decrementCount ? "Removed" : "Added")} {units}";

            AddGeneric(new BatchHistory { BatchId = Id, Units = units, Description = description });
            toUpdateTask.Result.AvailableUnits = existingCount + units;
            UpdateGeneric(toUpdateTask.Result);

            if (await SaveChangesAsync())
            {
                var updated = await GetById(Id);
                if (updated.AvailableUnits == existingCount + units)
                    return updated;
            }           
            return null;
        }
    }
}
