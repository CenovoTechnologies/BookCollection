using System.Data.Entity;
using BookCollection.Core;
using MySql.Data.Entity;
using System.Data.Common;

namespace BookCollection.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<BookFormat> BookFormats { get; set; }
        DbSet<BookGenre> BookGenres { get; set; }
        DbSet<Status> Statues { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbConnection existingConnection, bool contextOwnsConnection) 
            : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
