using System.Collections.Generic;

namespace BookCollection.Core.Interfaces
{
    public interface IBookService
    {
        IList<Book> RetrieveBooksByCollectionId(int collectionId);

        IList<Book> RetrieveBooksByAuthorId(int authorId);

        IList<Book> RetrieveBooksByGenre(int genre);

        IList<Book> RetrieveBooksByFormat(int format);

        Book RetrieveBookByBookId(int bookId);

        bool CheckIfBookExists(int bookId);

        void CreateNewBookInCollection(Book book);

        void UpdateBookInCollection(Book book);

        void DeleteBookFromCollection(Book book);
    }
}
