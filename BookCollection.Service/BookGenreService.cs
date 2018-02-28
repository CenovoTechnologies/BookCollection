using BookCollection.Core;
using System.Collections.Generic;
using BookCollection.Core.Interfaces;
using BookCollection.Repository.Interfaces;

namespace BookCollection.Service
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;

        public BookGenreService(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public IEnumerable<BookGenre> GetAllBookGenres()
        {
            return _readOnlyRepository.GetAllAsync<BookGenre>().Result;
        }

        public BookGenre GetBookGenreById(int bookGenreId)
        {
            return _readOnlyRepository.GetByIdAsync<BookGenre>(bookGenreId).Result;
        }
    }
}