using Felfel.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public class RepositoryBase : IRepositoryBase
    {        
        public InventoryContext Context { get; private set; }

        public RepositoryBase(InventoryContext context)
        {
            Context = context;
        }

        public virtual void AddGeneric<T>(T entity) where T : class
        {
            if (entity != null)
            {
                Context.Add(entity);
                if (entity is IEntityBase)
                    (entity as IEntityBase).CreatedAtUtc = DateTime.UtcNow;
            }
        }

        public virtual void DeleteGeneric<T>(T entity) where T : class
        {                        
            if (entity is IEntitySoftDeleteBase)
            {
                UpdateGeneric(entity);
                (entity as IEntitySoftDeleteBase).IsDeleted = true;                
            }
            else
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.Remove(entity);
            }
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync() >= 0;
        }

        public virtual void UpdateGeneric<T>(T entity) where T : class
        {
            if (entity != null)
            {
                Context.Entry(entity).State = EntityState.Modified;
                if (entity is IEntityBase)
                    (entity as IEntityBase).ModifiedAtUtc = DateTime.UtcNow;
            }
        }
        #region Dispose

        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && IsDisposed == false)
            {
                // dispose resources when needed
                IsDisposed = true;

                //TODO decide
                //_context.Dispose();
            }
        }

        #endregion
    }
}
