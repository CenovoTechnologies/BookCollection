using BookCollection.Core;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("BookCollection");

            modelBuilder.Entity<User>().HasKey(t => t.UserId);

            modelBuilder.Entity<BooksCollection>().HasKey(t => t.CollectionId);

            modelBuilder.Entity<BooksCollection>().ToTable("BookCollection");

            modelBuilder.Entity<BooksCollection>()
                .HasOne(x => x.User)
                .WithMany(y => y.BookCollections)
                .HasForeignKey(z => z.UserId);

            modelBuilder.Entity<BookGenre>().HasKey(t => t.BookGenreId);

            modelBuilder.Entity<BookFormat>().HasKey(t => t.BookFormatId);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(bc => new { bc.BookId, bc.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Author)
                .WithMany(c => c.BookAuthors)
                .HasForeignKey(bc => bc.AuthorId);

            modelBuilder.Entity<Author>()
                .HasOne(a => a.BooksCollection)
                .WithMany(b => b.Authors)
                .HasForeignKey(c => c.BookCollectionId);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.Collection)
                .WithMany(y => y.Books)
                .HasForeignKey(z => z.CollectionId);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.BookFormat)
                .WithMany(y => y.Books)
                .HasForeignKey(z => z.BookFormatId);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.BookGenre)
                .WithMany(y => y.Books)
                .HasForeignKey(z => z.BookGenreId);

            modelBuilder.Entity<BooksCollection>()
                .HasOne(x => x.User)
                .WithMany(y => y.BookCollections)
                .HasForeignKey(z => z.UserId);
        }
    }
}
