using System;
using BookCollection.Core;
using BookCollection.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Repository
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base (options)
        { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BookFormat> BookFormat { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<BooksCollection> BookCollection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(t => t.UserId);
            modelBuilder.Entity<User>(entity =>
                entity.Property(x => x.Email)
                    .HasMaxLength(200)
                    .IsRequired());
            modelBuilder.Entity<User>(entity =>
                entity.Property(x => x.FirstName)
                    .HasMaxLength(50)
                    .IsRequired());
            modelBuilder.Entity<User>(entity =>
                entity.Property(x => x.LastName)
                    .HasMaxLength(50)
                    .IsRequired());
            modelBuilder.Entity<User>(entity =>
                entity.Property(x => x.MiddleName)
                    .HasMaxLength(10));
            modelBuilder.Entity<User>(entity =>
                entity.Property(x => x.CreatedDate)
                    .HasDefaultValue(DateTime.UtcNow));
            modelBuilder.Entity<User>(entity =>
                entity.Property(x => x.ModifiedDate)
                    .HasDefaultValue(DateTime.UtcNow));

            modelBuilder.Entity<BookGenre>().ToTable("BookGenre");
            modelBuilder.Entity<BookGenre>().HasKey(t => t.BookGenreId);

            modelBuilder.Entity<BookFormat>().ToTable("BookFormat");
            modelBuilder.Entity<BookFormat>().HasKey(t => t.BookFormatId);

            modelBuilder.Entity<BookAuthor>().ToTable("BookAuthor");
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

            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Author>().HasKey(x => x.AuthorId);
            modelBuilder.Entity<Author>()
                .HasOne(a => a.BooksCollection)
                .WithMany(b => b.Authors)
                .HasForeignKey(c => c.BookCollectionId);
            modelBuilder.Entity<Author>(entity => 
                entity.Property(x => x.FirstName)
                    .HasMaxLength(100)
                    .IsRequired());
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.LastName)
                    .HasMaxLength(100)
                    .IsRequired());
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.MiddleName)
                    .HasMaxLength(10));
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.BirthPlace)
                    .HasMaxLength(150));
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.DeathPlace)
                    .HasMaxLength(150));
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.WikipediaLink)
                    .HasMaxLength(150));
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.WebsiteLink)
                    .HasMaxLength(150));
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.Pseudonym)
                    .HasMaxLength(100));
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.CreatedDate)
                    .HasDefaultValue(DateTime.UtcNow));
            modelBuilder.Entity<Author>(entity =>
                entity.Property(x => x.ModifiedDate)
                    .HasDefaultValue(DateTime.UtcNow));

            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Book>().HasKey(x => x.BookId);
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
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.Title)
                    .HasMaxLength(200)
                    .IsRequired());
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.SubTitle)
                    .HasMaxLength(200));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.Isbn)
                    .HasMaxLength(100));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.NumberOfPages)
                    .HasMaxLength(10));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.LocClassification)
                    .HasMaxLength(100));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.Dewey)
                    .HasMaxLength(100));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.Publisher)
                    .HasMaxLength(150));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.Plot)
                    .HasMaxLength(400));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.CreatedDate)
                    .HasDefaultValue(DateTime.UtcNow));
            modelBuilder.Entity<Book>(entity =>
                entity.Property(x => x.ModifiedDate)
                    .HasDefaultValue(DateTime.UtcNow));

            modelBuilder.Entity<BooksCollection>().ToTable("BookCollection");
            modelBuilder.Entity<BooksCollection>().HasKey(t => t.CollectionId);
            modelBuilder.Entity<BooksCollection>()
                .HasOne(x => x.User)
                .WithMany(y => y.BookCollections)
                .HasForeignKey(z => z.UserId);
            modelBuilder.Entity<BooksCollection>()
                .HasOne(x => x.User)
                .WithMany(y => y.BookCollections)
                .HasForeignKey(z => z.UserId);
            modelBuilder.Entity<BooksCollection>(entity =>
                entity.Property(x => x.CollectionName)
                    .HasMaxLength(100)
                    .IsRequired());
            modelBuilder.Entity<BooksCollection>(entity =>
                entity.Property(x => x.CreatedDate)
                    .HasDefaultValue(DateTime.UtcNow));
            modelBuilder.Entity<BooksCollection>(entity =>
                entity.Property(x => x.ModifiedDate)
                    .HasDefaultValue(DateTime.UtcNow));
        }
    }
}
