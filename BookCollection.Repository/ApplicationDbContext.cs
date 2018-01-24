using System.Data.Entity;
using System.Data.SQLite;
using BookCollection.Core;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookCollection.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BookFormat> BookFormats { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<BooksCollection> BookCollection { get; set; }

        public ApplicationDbContext() 
            : base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = "C:\\Users\\melissaSusan\\Source\\Repos\\BookCollection\\BookCollection.db", ForeignKeys = true
                }.ConnectionString
            }, true)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
            //CreateBookAuthorRelationship(modelBuilder);
            //CreateBookCollectionRelationship(modelBuilder);
            //CreateUserCollectionRelationship(modelBuilder);
        }

        private void CreateBookAuthorRelationship(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany<Author>(x => x.Authors)
                .WithMany(y => y.Books)
                .Map(xy =>
                {
                    xy.MapLeftKey("BookRefId");
                    xy.MapRightKey("AuthorRefId");
                    xy.ToTable("BookAuthor");
                });
        }

        private void CreateBookCollectionRelationship(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasRequired<BooksCollection>(x => x.Collection)
                .WithMany(y => y.Collection)
                .HasForeignKey(z => z.CollectionId);
        }

        private void CreateUserCollectionRelationship(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksCollection>()
                .HasRequired<User>(x => x.User)
                .WithMany(y => y.BookCollections)
                .HasForeignKey(z => z.UserId);
        }
    }
}
