using BookCollection.Core;

namespace BookCollection.Repository.UnitofWork
{
    public class BookUnitofWork : BaseUnitofWork
    {
        public void AddNewBook(Book book)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Create(book);
                Save();
            }
        }

        public void UpdateBook(Book book)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Update(book);
                Save();
            }
        }

        public void DeleteBook(Book book)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Delete(book);
                Save();
            }
        }

        public bool Exists(Book book)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).Exists(book);
            }
        }
    }
}
