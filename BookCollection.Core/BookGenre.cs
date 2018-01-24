
using System.Collections.Generic;

namespace BookCollection.Core
{
    public partial class BookGenre
    {
        public int BookGenreId { get; set; }
        public string Genre { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
