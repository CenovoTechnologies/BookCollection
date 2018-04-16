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
            _repository.Save();
        }

        public void UpdateCollection(BooksCollection booksCollection)
        {
            _repository.Update(booksCollection);
            _repository.Save();
        }

        public void DeleteCollection(BooksCollection booksCollection)
        {
            _repository.Delete(booksCollection);
            _repository.Save();
        }

        public void DeleteCollectionById(int collectionId)
        {
            _repository.Delete<BooksCollection>(collectionId);
            _repository.Save();
        }

        public BooksCollection RetrieveCollectionsByCollectionId(int collectionId)
        {
            var collection = _readOnlyRepository.GetAsync<BooksCollection>(x => x.CollectionId == collectionId, "Books,Authors").Result.First();
            foreach (var book in collection.Books)
            {
                book.BookAuthors = _readOnlyRepository.GetAll<BookAuthor>(x => x.BookId == book.BookId)
                    .Select(ab => new BookAuthor
                    {
                        AuthorId = ab.AuthorId,
                        BookId = ab.BookId
                    })
                    .ToList();
            }
            foreach (var author in collection.Authors)
            {
                author.BookAuthors = _readOnlyRepository.GetAll<BookAuthor>(x => x.AuthorId == author.AuthorId)
                    .Select(ab => new BookAuthor
                    {
                        AuthorId = ab.AuthorId,
                        BookId = ab.BookId
                    })
                    .ToList();
            }
            return collection;
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
