using Felfel.Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public interface IBatchRepository: IGenericRepository
    {
        Task<int> GetAvailableUnits(int Id);
    }

    public class BatchRepository : GenericRepository, IBatchRepository
    {
        public BatchRepository(InventoryContext context) : base(context)
        {

        }

        public Task<int> GetAvailableUnits(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
