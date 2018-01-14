using BookCollection.Core.Interfaces;
using System.Threading.Tasks;

namespace BookCollection.Repository.Interfaces
{
    public interface IRepository : IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class;

        void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class;

        void Delete<TEntity>(object id) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void Save();

        Task SaveAsync();
    }
}
