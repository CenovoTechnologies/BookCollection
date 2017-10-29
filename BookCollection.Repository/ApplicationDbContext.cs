using System.Data.Entity;
using BookCollection.Core;
using MySql.Data.Entity;
using System.Data.Common;

namespace BookCollection.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookFormat> BookFormats { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Status> Statues { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbConnection existingConnection, bool contextOwnsConnection) 
            : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
