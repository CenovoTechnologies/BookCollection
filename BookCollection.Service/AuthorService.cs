using System.Collections.Generic;
using System.Linq;
using BookCollection.Core;
using BookCollection.Core.Interfaces;
using BookCollection.Repository.Interfaces;

namespace BookCollection.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;

        public AuthorService(IReadOnlyRepository readOnlyRepository, IRepository repository)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
        }

        public IList<Author> RetrieveAuthorsByCollectionId(int collectionId)
        {
            return _readOnlyRepository.GetAllAsync<Author>(x => x.BookCollectionId == collectionId).Result.ToList();
        }

        public IList<Author> RetrieveAuthorsByBookId(int bookId)
        {
            var authorIds = _readOnlyRepository.GetAllAsync<BookAuthor>(y => y.BookId == bookId).Result;
            return authorIds.Select(bookAuthor => _readOnlyRepository.GetAsync<Author>(x => x.AuthorId == bookAuthor.AuthorId).Result.First()).ToList();
        }

        public Author RetrieveAuthorByAuthorId(int authorId)
        {
            return _readOnlyRepository.GetByIdAsync<Author>(authorId).Result;
        }

        public bool CheckIfAuthorExists(int id)
        {
            return _readOnlyRepository.Exists<Author>(x => x.AuthorId == id);
        }

        public void CreateNewAuthor(Author author)
        {
            _repository.Create(author);
            _repository.SaveAsync();
        }

        public void CreateNewAuthors(IList<Author> authors)
        {
            foreach (var author in authors)
            {
                _repository.Create(author);
            }
            _repository.SaveAsync();
        }

        public void UpdateAuthor(Author author)
        {
            _repository.Update(author);
            _repository.Save();
        }
    }
}
