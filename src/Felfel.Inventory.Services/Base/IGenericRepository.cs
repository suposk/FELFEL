using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public interface IGenericRepository: IRepositoryBase
    {

        Task<T> GetById<T>(int Id) where T : class;

        Task<T> GetByFilter<T>(Expression<Func<T, bool>> expression) where T : class;

        Task<List<T>> GetList<T>() where T : class;

        Task<List<T>> GetListFilter<T>(Expression<Func<T, bool>> expression) where T : class;
    }
}
