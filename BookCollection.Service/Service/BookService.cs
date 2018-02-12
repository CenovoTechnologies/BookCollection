using BookCollection.Core;
using BookCollection.Repository;
using BookCollection.Repository.UnitofWork;
using System.Collections.Generic;

namespace BookCollection.Service.Service
{
    public class BookService : Service
    {
        private ApplicationDbContext db;

        public IList<Book> RetrieveBooksByCollectionId(int collectionId)
        {
            return new BookUnitofWork().RetrieveBooksByCollectionId(collectionId);
        }

        public IList<Book> RetrieveBooksByAuthorId(int authorId)
        {
            return new BookUnitofWork().RetrieveBooksByAuthorId(authorId);
        }

        public IList<Book> RetrieveBooksByGenre(BookGenre genre)
        {
            return new BookUnitofWork().RetrieveBooksByGenre(genre);
        }

        public IList<Book> RetrieveBooksByFormat(BookFormat format)
        {
            return new BookUnitofWork().RetrieveBooksByFormat(format);
        }

        public Book RetrieveBookByBookId(int bookId)
        {
            using (db = new ApplicationDbContext())
            {
                return db.Book.Find(bookId);
            }
        }

        public bool CheckIfBookExists(int bookId)
        {
            using (db = new ApplicationDbContext())
            {
                if (db.Book.Find(bookId) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CreateNewBookInCollection(Book book)
        {
            new BookUnitofWork().AddNewBook(book);
            return true;
        }

        public bool UpdateBookInCollection(Book book)
        {
            new BookUnitofWork().UpdateBook(book);
            return true;
        }

        public void DeleteBookFromCollection(Book book)
        {
            new BookUnitofWork().DeleteBook(book);
        }
    }
}
