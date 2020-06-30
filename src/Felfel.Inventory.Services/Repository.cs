using Felfel.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext DatabaseContext;

        public Repository(DbContext context)
        {
            this.DatabaseContext = context;
        }

        public Task<List<TModel>> GetAllAsync()
        {
            return DatabaseContext.Set<TModel>().ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            return await DatabaseContext.Set<TModel>().FindAsync(id);
        }

        public Task<TModel> GetByFilter(Expression<Func<TModel, bool>> expression)
        {
            return DatabaseContext.Set<TModel>().FirstOrDefaultAsync(expression);
        }

        public Task<List<TModel>> GetListFilter(Expression<Func<TModel, bool>> expression)
        {
            return DatabaseContext.Set<TModel>().Where(expression).ToListAsync();
        }

        public void Add(TModel entity)
        {
            if (entity != null)
            {
                DatabaseContext.Add(entity);
                if (entity is IEntityBase)
                    (entity as IEntityBase).CreatedAtUtc = DateTime.UtcNow;
            }
        }


        public void UpdateGeneric(TModel entity)
        {
            if (entity != null)
            {
                DatabaseContext.Entry(entity).State = EntityState.Modified;
                if (entity is IEntityBase)
                    (entity as IEntityBase).ModifiedAtUtc = DateTime.UtcNow;
            }
        }

        public void Delete(TModel entity)
        {
            if (entity is IEntitySoftDeleteBase)
            {
                UpdateGeneric(entity);
                (entity as IEntitySoftDeleteBase).IsDeleted = true;
            }
            else
            {
                DatabaseContext.Entry(entity).State = EntityState.Deleted;
                DatabaseContext.Remove(entity);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await DatabaseContext.SaveChangesAsync() >= 0;
        }
    }
}
