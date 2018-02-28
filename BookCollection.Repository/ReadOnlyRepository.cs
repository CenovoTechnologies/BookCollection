using BookCollection.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Repository
{
    public class ReadOnlyRepository : IReadOnlyRepository
    {
        private readonly ApplicationDbContext _context;

        public ReadOnlyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            includeProperties?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            return GetQueryable(filter, includeProperties).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            return await GetQueryable<TEntity>(null, includeProperties).ToListAsync();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            return GetQueryable(filter, includeProperties).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            return await GetQueryable(filter, includeProperties).ToListAsync();
        }

        public TEntity GetById<TEntity>(object id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return GetQueryable(filter).Count();
        }

        public bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return _context.Set<TEntity>().Any(filter);
        }
    }
}
