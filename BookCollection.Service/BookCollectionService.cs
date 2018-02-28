using BookCollection.Core;
using System.Collections.Generic;
using System.Linq;
using BookCollection.Core.Interfaces;
using BookCollection.Repository.Interfaces;

namespace BookCollection.Service
{
    public class BookCollectionService : IBookCollectionService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;

        public BookCollectionService(IReadOnlyRepository readOnlyRepository, IRepository repository)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
        }

        public void CreateNewCollection(BooksCollection booksCollection)
        {
            _repository.Create(booksCollection);
        }

        public void UpdateCollection(BooksCollection booksCollection)
        {
            _repository.Update(booksCollection);
        }

        public void DeleteCollection(BooksCollection booksCollection)
        {
            _repository.Delete(booksCollection);
        }

        public void DeleteCollectionById(int collectionId)
        {
            _repository.Delete<BooksCollection>(collectionId);
        }

        public BooksCollection RetrieveCollectionsByCollectionId(int collectionId)
        {
            return _readOnlyRepository.GetByIdAsync<BooksCollection>(collectionId).Result;
        }

        public IList<BooksCollection> RetrieveCollectionsByUserId(int userId)
        {
            return _readOnlyRepository.GetAsync<BooksCollection>(x => x.UserId == userId).Result.ToList();
        }

        public bool CheckIfCollectionExists(int collectionId)
        {
            return _readOnlyRepository.Exists<BooksCollection>(x => x.CollectionId == collectionId);
        }

        public bool CheckIfCollectionNameExists(int userId, string collectionName)
        {
            return _readOnlyRepository.Exists<BooksCollection>(x => x.UserId == userId && x.CollectionName.Equals(collectionName));
        }

        public bool IsBookAlreadyInCollection(Book book)
        {
            return _readOnlyRepository.Exists<BooksCollection>(x => x.Books.Any(y => y.Equals(book)));
        }
    }
}
