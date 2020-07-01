using Felfel.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace Felfel.Inventory.Services
{

    public class SummaryRepository : GenericRepository, ISummaryRepository
    {
        public SummaryRepository(InventoryContext context) : base(context)
        {

        }

        public Task<List<Batch>> GetFreshness(FreshnesState freshnesState)
        {
            Expression<Func<Batch, bool>> expression = null;
            switch (freshnesState)
            {
                case FreshnesState.Fresh:
                    expression = (a => a.ExpirationDate > DateTime.UtcNow.AddDays(-1));                    
                    break;                    
                case FreshnesState.ExpiresToday:
                    expression = (a => a.ExpirationDate.DayOfYear == DateTime.UtcNow.DayOfYear);
                    break;
                case FreshnesState.Expired:
                    expression = (a => a.ExpirationDate < DateTime.UtcNow.AddDays(-1));
                    break;
            }
            return Context.Batchs.Include(a => a.Product).Where(expression).ToListAsync();            
        }
    }
}
