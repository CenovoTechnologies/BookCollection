using BookCollection.Core;
using System.Collections.Generic;
using System.Linq;

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

        public Book RetrieveBookByBookId(int bookId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).GetById<Book>(bookId);
            }
        }

        public List<Book> RetrieveBooksByAuthorId(int authorId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var repo = RepositoryGetter.RetrieveReadOnlyRepository(DbContext);
                return repo.GetAll<Book>().Where(x => x.Authors.FirstOrDefault().AuthorId == authorId).ToList();
            }
        }

        public List<Book> RetrieveBooksByCollectionId(int collectionId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var repo = RepositoryGetter.RetrieveReadOnlyRepository(DbContext);
                return repo.GetAll<Book>(x => x.CollectionId == collectionId).ToList();
            }
        }

        public List<Book> RetrieveBooksByGenre(int genre)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var repo = RepositoryGetter.RetrieveReadOnlyRepository(DbContext);
                return repo.GetAll<Book>(x => x.BookGenreId == genre).ToList();
            }
        }

        public List<Book> RetrieveBooksByFormat(int format)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var repo = RepositoryGetter.RetrieveReadOnlyRepository(DbContext);
                return repo.GetAll<Book>(x => x.BookFormatId == format).ToList();
            }
        }
    }
}
