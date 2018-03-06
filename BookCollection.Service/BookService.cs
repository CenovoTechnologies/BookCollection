using BookCollection.Core;
using System.Collections.Generic;
using System.Linq;
using BookCollection.Core.Interfaces;
using BookCollection.Repository.Interfaces;

namespace BookCollection.Service
{
    public class BookService : IBookService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;

        public BookService(IReadOnlyRepository readOnlyRepository, IRepository repository)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
        }

        public IList<Book> RetrieveBooksByCollectionId(int collectionId)
        {
            return _readOnlyRepository.GetAllAsync<Book>(x => x.CollectionId == collectionId).Result.ToList();
        }

        public IList<Book> RetrieveBooksByAuthorId(int authorId)
        {
            return _readOnlyRepository.GetAllAsync<Book>(x => x.BookAuthors.Any(y => y.AuthorId == authorId)).Result.ToList();
        }

        public IList<Book> RetrieveBooksByGenre(int genre)
        {
            return _readOnlyRepository.GetAllAsync<Book>(x => x.BookGenreId == genre).Result.ToList();
        }

        public IList<Book> RetrieveBooksByFormat(int format)
        {
            return _readOnlyRepository.GetAllAsync<Book>(x => x.BookFormatId == format).Result.ToList();
        }

        public Book RetrieveBookByBookId(int bookId)
        {
            return _readOnlyRepository.GetByIdAsync<Book>(bookId).Result;
        }

        public bool CheckIfBookExists(int bookId)
        {
            return _readOnlyRepository.Exists<Book>(x => x.BookId == bookId);
        }

        public void CreateNewBookInCollection(Book book)
        {
            _repository.Create(book);
            _repository.Save();
        }

        public void UpdateBookInCollection(Book book)
        {
            _repository.Update(book);
            _repository.Save();
        }

        public void DeleteBookFromCollection(Book book)
        {
            _repository.Delete(book);
            _repository.Save();
        }
    }
}
