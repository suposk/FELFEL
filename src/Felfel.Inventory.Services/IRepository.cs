using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public interface IRepository<TModel> where TModel : class
    {       
        Task<TModel> GetByIdAsync(int id);      
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByFilter(Expression<Func<TModel, bool>> expression);        
        Task<List<TModel>> GetListFilter(Expression<Func<TModel, bool>> expression);
        void Add(TModel entity);
        void Delete(TModel entity);
        Task<bool> SaveChangesAsync();
    }
}
