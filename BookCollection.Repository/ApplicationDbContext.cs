using System.Data.Entity;
using System.Data.SQLite;
using BookCollection.Core;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookCollection.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BookFormat> BookFormat { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<BooksCollection> BookCollection { get; set; }

        public ApplicationDbContext() 
            : base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = "C:\\Users\\melissaSusan\\Source\\Repos\\BookCollection\\BookCollection.db", ForeignKeys = true
                }.ConnectionString
            }, true)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new BookCollectionDBInitializer(modelBuilder));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("BookCollection");

            modelBuilder.Entity<User>().HasKey(t => t.UserId);

            modelBuilder.Entity<BooksCollection>().HasKey(t => t.CollectionId);

            modelBuilder.Entity<BooksCollection>().ToTable("BookCollection");

            modelBuilder.Entity<BooksCollection>()
                .HasRequired(x => x.User)
                .WithMany(y => y.BookCollections)
                .HasForeignKey(z => z.UserId);

            modelBuilder.Entity<BookGenre>().HasKey(t => t.BookGenreId);

            modelBuilder.Entity<BookFormat>().HasKey(t => t.BookFormatId);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(y => y.Books)
                .Map(xy =>
                {
                    xy.MapLeftKey("BookRefId");
                    xy.MapRightKey("AuthorRefId");
                    xy.ToTable("BookAuthor");
                });

            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Collection)
                .WithMany(y => y.Collection)
                .HasForeignKey(z => z.CollectionId);

            modelBuilder.Entity<Book>()
                .HasRequired(x => x.BookFormat)
                .WithMany(y => y.Books)
                .HasForeignKey(z => z.BookFormatId);

            modelBuilder.Entity<Book>()
                .HasRequired(x => x.BookGenre)
                .WithMany(y => y.Books)
                .HasForeignKey(z => z.BookGenreId);

            modelBuilder.Entity<BooksCollection>()
                .HasRequired(x => x.User)
                .WithMany(y => y.BookCollections)
                .HasForeignKey(z => z.UserId);
        }
    }
}
