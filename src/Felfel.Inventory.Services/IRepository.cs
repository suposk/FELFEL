﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Felfel.Inventory.Services
{
    public interface IRepository<TModel> where TModel : class
    {
        TModel Get(int id);

        Task<TModel> GetAsync(int id);
        List<TModel> GetAll();

        Task<List<TModel>> GetAllAsync();
        void Add(TModel entity);
        void Remove(TModel entity);

        Task<bool> SaveChangesAsync();
    }
}
