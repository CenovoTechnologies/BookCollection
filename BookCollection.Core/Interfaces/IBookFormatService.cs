using System.Collections.Generic;

namespace BookCollection.Core.Interfaces
{
    public interface IBookFormatService
    {
        IEnumerable<BookFormat> GetAllBookFormats();

        BookFormat GetBookFormatById(int bookFormatId);
    }
}
