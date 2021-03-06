﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookCollection.Repository.Interfaces
{
    public interface IReadOnlyRepository
    {
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        TEntity GetById<TEntity>(object id) where TEntity : class;

        Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class;

        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
       
        bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;
    }
}
