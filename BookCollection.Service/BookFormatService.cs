using BookCollection.Core;
using System.Collections.Generic;
using BookCollection.Core.Interfaces;
using BookCollection.Repository.Interfaces;

namespace BookCollection.Service
{
    public class BookFormatService : IBookFormatService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;

        public BookFormatService(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public IEnumerable<BookFormat> GetAllBookFormats()
        {
            return _readOnlyRepository.GetAllAsync<BookFormat>().Result;
        }

        public BookFormat GetBookFormatById(int bookFormatId)
        {
            return _readOnlyRepository.GetByIdAsync<BookFormat>(bookFormatId).Result;
        }
    }
}