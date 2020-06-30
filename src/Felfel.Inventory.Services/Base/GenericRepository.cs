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

        public async Task<T> GetById<T>(int Id) where T : class
        {
            var ent = await Context.FindAsync<T>(Id);
            return ent;
        }

        public Task<T> GetByFilter<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Context.Set<T>().FirstOrDefaultAsync(expression);            
        }

        public Task<List<T>> GetList<T>() where T : class
        {
            return Context.Set<T>().ToListAsync();            
        }

        public Task<List<T>> GetListFilter<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Context.Set<T>().Where(expression).ToListAsync();            
        }

    }
}
