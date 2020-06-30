using Felfel.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Felfel.Inventory.Services
{
    public interface IBatchRepository: IGenericRepository
    {
        Task<int> GetAvailableUnits(int Id);

        Task<Batch> UpdateUnits(int Id, int units, string description, bool decrementCount);
    }

    public class BatchRepository : GenericRepository, IBatchRepository
    {
        public BatchRepository(InventoryContext context) : base(context)
        {

        }

        public Task<int> GetAvailableUnits(int Id)
        {
            return Context.BatchHistorys.Where(a =>a.BatchId == Id).SumAsync(a => a.Units);
        }

        public async Task<Batch> UpdateUnits(int Id, int units, string description, bool decrementCount)
        {
            var toUpdateTask = GetById<Batch>(Id);
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

            if (string.IsNullOrWhiteSpace(description))
                description = $"{(decrementCount ? "Removed" : "Added")} {units}";

            AddGeneric(new BatchHistory { BatchId = Id, Units = units, Description = description });
            toUpdateTask.Result.AvailableUnits = existingCount + units;
            UpdateGeneric(toUpdateTask.Result);

            if (await SaveChangesAsync())
            {
                var updated = await GetById<Batch>(Id);
                if (updated.AvailableUnits == existingCount + units)
                    return updated;
            }           
            return null;
        }
    }
}
