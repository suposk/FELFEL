using Felfel.Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Felfel.Inventory.Services
{
    public interface IBatchRepository: IGenericRepository
    {
        Task<int> GetAvailableUnits(int Id);

        Task<List<Batch>> GetFilter(Expression<Func<Batch, bool>> expression);
        
        Task<Batch> GetById(int Id);

        Task<bool> AddBatch(Batch batch);

        Task<Batch> UpdateUnits(int Id, int units, string description, bool decrementCount);
    }
}
