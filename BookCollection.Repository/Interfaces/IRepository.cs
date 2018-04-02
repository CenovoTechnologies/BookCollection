using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookCollection.Repository.Interfaces
{
    public interface IRepository
    {
        void Create<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        IDbContextTransaction BeginTransaction();

        void Delete<TEntity>(object id) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void Save();

        Task SaveAsync();
    }
}
