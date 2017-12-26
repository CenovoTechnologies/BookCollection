using BookCollection.Core;
using BookCollection.Repository.UnitofWork;
using System.Collections.Generic;

namespace BookCollection.Service.Service
{
    public class BookCollectionService : Service
    {
        private BookCollectionUnitOfWork work = new BookCollectionUnitOfWork();

        public void CreateNewCollection(BooksCollection collection)
        {
            work.AddNewBookCollection(collection);
        }

        public void UpdateCollection(BooksCollection collection)
        {
            work.UpdateBookCollection(collection);
        }

        public bool DeleteCollection(BooksCollection collection)
        {
            return work.DeleteBookCollection(collection);
        }

        public bool DeleteCollectionById(int collectionId)
        {
            return work.DeleteBookCollectionById(collectionId);
        }

        public BooksCollection RetrieveCollectionsByCollectionId(int collectionId)
        {
            return work.RetrieveBookCollectionByCollectionId(collectionId);
        }

        public List<BooksCollection> RetrieveCollectionsByUserId(int userId)
        {
            return work.RetrieveBooksCollectionByUserId(userId);
        }

        public bool CheckIfCollectionExists(int collectionId)
        {
            return work.CheckIfCollectionExists(collectionId);
        }

        public bool CheckIfCollectionNameExists(int userId, string collectionName)
        {
            return work.CheckIfCollectionNameExists(userId, collectionName);
        }

        public bool IsBookAlreadyInCollection(Book book)
        {
            return false;
        }

        public void RemoveBookFromCollection(Book book)
        {
        }
    }
}
