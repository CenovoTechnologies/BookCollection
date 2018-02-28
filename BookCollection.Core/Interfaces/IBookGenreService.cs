using System.Collections.Generic;

namespace BookCollection.Core.Interfaces
{
    public interface IBookGenreService
    {
        IEnumerable<BookGenre> GetAllBookGenres();

        BookGenre GetBookGenreById(int bookGenreId);
    }
}
