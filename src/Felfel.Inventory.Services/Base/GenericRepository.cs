using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Felfel.Inventory.Entities;

namespace Felfel.Inventory.Services
{
    public class GenericRepository : RepositoryBase, IGenericRepository
    {        
        public GenericRepository(InventoryContext context) : base(context)
        {
            
        }

        public virtual async Task<T> GetByIdGeneric<T>(int Id) where T : class
        {
            var ent = await Context.FindAsync<T>(Id);
            return ent;
        }

        public virtual Task<T> GetByFilterGeneric<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Context.Set<T>().FirstOrDefaultAsync(expression);            
        }

        public virtual Task<List<T>> GetListGeneric<T>() where T : class
        {
            return Context.Set<T>().ToListAsync();            
        }

        public virtual Task<List<T>> GetListFilterGeneric<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Context.Set<T>().Where(expression).ToListAsync();            
        }

    }
}
