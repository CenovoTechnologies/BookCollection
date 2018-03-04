using BookCollection.Core;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Repository.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Book { get; set; }
        DbSet<Author> Author { get; set; }
        DbSet<User> User { get; set; }
        DbSet<BookFormat> BookFormat { get; set; }
        DbSet<BookGenre> BookGenre { get; set; }
        DbSet<BooksCollection> BookCollection { get; set; }
    }
}
