using BookCollection.Core;
using BookCollection.Repository.UnitofWork;
using System.Collections.Generic;

namespace BookCollection.Services
{
    public class BookService : Service
    {
        public List<Book> RetrieveBooksByCollectionId(int collectionId)
        {
            return new BookUnitofWork().RetrieveBooksByCollectionId(collectionId);
        }

        public List<Book> RetrieveBooksByAuthorId(int authorId)
        {
            return new BookUnitofWork().RetrieveBooksByAuthorId(authorId);
        }

        public Book RetrieveBookByAuthorId(int bookId)
        {
            return new BookUnitofWork().RetrieveBookByBookId(bookId);
        }

        public bool CheckIfBookExists(Book book)
        {
            return new BookUnitofWork().Exists(book);
        }

        public void CreateNewBook(Book book)
        {
            new BookUnitofWork().AddNewBook(book);
        }
    }
}
