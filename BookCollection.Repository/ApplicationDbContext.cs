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
        public DbSet<Status> Statuses { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbConnection existingConnection, bool contextOwnsConnection) 
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CreateBookAuthorRelationship(modelBuilder);
            CreateBookCollectionRelationship(modelBuilder);
            CreateUserCollectionRelationship(modelBuilder);
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
