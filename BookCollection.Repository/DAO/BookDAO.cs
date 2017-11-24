using BookCollection.Core;

namespace BookCollection.Repository.DAO
{
    public class BookDao : BaseDAO
    {
        public void AddNewBook(Book book)
        {
            using (dbContext = new ApplicationDbContext())
            {
                var repo = RetrieveRepository(dbContext);
                repo.Create(book);
                Save();
            }
        }

        public void UpdateBook(Book book)
        {
            using (dbContext = new ApplicationDbContext())
            {
                var repo = RetrieveRepository(dbContext);
                repo.Update(book);
                Save();
            }
        }

        public void DeleteBook(Book book)
        {
            using (dbContext = new ApplicationDbContext())
            {
                var repo = RetrieveRepository(dbContext);
                repo.Delete(book);
                Save();
            }
        }
    }
}
