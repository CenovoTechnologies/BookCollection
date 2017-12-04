using BookCollection.Core;

namespace BookCollection.Repository.UnitofWork
{
    public class AuthorUnitofWork : BaseUnitofWork
    {
        public void AddNewUser(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Create(author);
                Save();
            }
        }

        public void UpdateUser(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Update(author);
                Save();
            }
        }

        public void DeleteUser(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Delete(author);
                Save();
            }
        }

        public bool Exists(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).Exists(author); ;
            }
        }
    }
}
