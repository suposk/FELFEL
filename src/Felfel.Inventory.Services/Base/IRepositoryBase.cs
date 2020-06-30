using Felfel.Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    /// <summary>
    /// base for repository with IDisposable
    /// </summary>
    public interface IRepositoryBase: IDisposable
    {
        // General        
        InventoryContext Context { get; }

        void AddGeneric<T>(T entity) where T : class;
        
        void DeleteGeneric<T>(T entity) where T : class;

        void UpdateGeneric<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        bool IsDisposed { get; }
    }
}
