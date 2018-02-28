using System.Collections.Generic;

namespace BookCollection.Core.Interfaces
{
    public interface IBookCollectionService
    {
        void CreateNewCollection(BooksCollection booksCollection);

        void UpdateCollection(BooksCollection booksCollection);

        void DeleteCollection(BooksCollection booksCollection);

        void DeleteCollectionById(int collectionId);

        BooksCollection RetrieveCollectionsByCollectionId(int collectionId);

        IList<BooksCollection> RetrieveCollectionsByUserId(int userId);

        bool CheckIfCollectionExists(int collectionId);

        bool CheckIfCollectionNameExists(int userId, string collectionName);

        bool IsBookAlreadyInCollection(Book book);
    }
}
