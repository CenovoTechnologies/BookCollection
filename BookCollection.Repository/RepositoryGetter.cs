using BookCollection.Repository.Interfaces;

namespace BookCollection.Repository
{
    public class RepositoryGetter
    {
        public static IRepository RetrieveCollectionRepository(ApplicationDbContext dbContext)
        {
            return new CollectionRepository<ApplicationDbContext>(dbContext);
        }

        public static IReadOnlyRepository RetrieveReadOnlyRepository(ApplicationDbContext dbContext)
        {
            return new ReadOnlyRepository<ApplicationDbContext>(dbContext);
        }
    }
}
