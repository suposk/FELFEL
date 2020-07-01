using Felfel.Inventory.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public interface ISummaryRepository 
    {
        Task<List<Batch>> GetFreshness(FreshnesState freshnesState);
    }
}
