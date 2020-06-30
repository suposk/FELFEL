using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public interface IGenericRepository: IRepositoryBase
    {

        Task<T> GetByIdGeneric<T>(int Id) where T : class;

        Task<T> GetByFilterGeneric<T>(Expression<Func<T, bool>> expression) where T : class;

        Task<List<T>> GetListGeneric<T>() where T : class;

        Task<List<T>> GetListFilterGeneric<T>(Expression<Func<T, bool>> expression) where T : class;
    }
}
