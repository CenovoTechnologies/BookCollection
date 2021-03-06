﻿using BookCollection.Repository.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookCollection.Repository
{
    public class CollectionRepository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public CollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Add(entity);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(object id) where TEntity : class
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var dbSet = _context.Set<TEntity>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
