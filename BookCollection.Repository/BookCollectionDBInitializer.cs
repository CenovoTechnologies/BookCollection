using BookCollection.Core;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookCollection.Repository
{
    public class BookCollectionDBInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.BookGenre.AddRange(GetDataToSeedBookGenre());
            context.BookFormat.AddRange(GetDataToSeedBookFormat());
            base.Seed(context);
        }

        public IList<BookGenre> GetDataToSeedBookGenre()
        {
            return new List<BookGenre>
            {
                new BookGenre { BookGenreId = 1, Genre = "Adventure" },
                new BookGenre { BookGenreId = 2, Genre = "Art"},
                new BookGenre { BookGenreId = 3, Genre = "Autobiography" },
                new BookGenre { BookGenreId = 4, Genre = "Biography" },
                new BookGenre { BookGenreId = 5, Genre = "Business" },
                new BookGenre { BookGenreId = 6, Genre = "Children's Literature" },
                new BookGenre { BookGenreId = 7, Genre = "Christian" },
                new BookGenre { BookGenreId = 8, Genre = "Classics" },
                new BookGenre { BookGenreId = 9, Genre = "Comics" },
                new BookGenre { BookGenreId = 10, Genre = "Contemporary" },
                new BookGenre { BookGenreId = 11, Genre = "Cookbook" },
                new BookGenre { BookGenreId = 12, Genre = "Crime" },
                new BookGenre { BookGenreId = 13, Genre = "Fantasic Fiction" },
                new BookGenre { BookGenreId = 14, Genre = "Fantasy" },
                new BookGenre { BookGenreId = 15, Genre = "Fiction" },
                new BookGenre { BookGenreId = 16, Genre = "Gay and Lesbian" },
                new BookGenre { BookGenreId = 17, Genre = "Graphic Novels" },
                new BookGenre { BookGenreId = 18, Genre = "Health" },
                new BookGenre { BookGenreId = 19, Genre = "Historical Fiction" },
                new BookGenre { BookGenreId = 20, Genre = "History" },
                new BookGenre { BookGenreId = 21, Genre = "Hobby" },
                new BookGenre { BookGenreId = 22, Genre = "Horror" },
                new BookGenre { BookGenreId = 23, Genre = "Humor and Comedy" },
                new BookGenre { BookGenreId = 24, Genre = "Literature" },
                new BookGenre { BookGenreId = 25, Genre = "Manga" },                
                new BookGenre { BookGenreId = 26, Genre = "Memoir" },
                new BookGenre { BookGenreId = 27, Genre = "Music" },
                new BookGenre { BookGenreId = 28, Genre = "Mystery" },
                new BookGenre { BookGenreId = 29, Genre = "Non-Fiction" },
                new BookGenre { BookGenreId = 30, Genre = "Paranormal" },
                new BookGenre { BookGenreId = 31, Genre = "Philosophy" },
                new BookGenre { BookGenreId = 32, Genre = "Poetry" },
                new BookGenre { BookGenreId = 33, Genre = "Psychology" },
                new BookGenre { BookGenreId = 34, Genre = "Reference" },
                new BookGenre { BookGenreId = 35, Genre = "Religion" },
                new BookGenre { BookGenreId = 36, Genre = "Romance" },
                new BookGenre { BookGenreId = 37, Genre = "Science Fiction" },
                new BookGenre { BookGenreId = 38, Genre = "Scientific" },
                new BookGenre { BookGenreId = 39, Genre = "Self-Help" },
                new BookGenre { BookGenreId = 40, Genre = "Suspense" },
                new BookGenre { BookGenreId = 41, Genre = "Spirituality" },
                new BookGenre { BookGenreId = 42, Genre = "Sports" },
                new BookGenre { BookGenreId = 43, Genre = "Thriller" },
                new BookGenre { BookGenreId = 44, Genre = "Travel" },
                new BookGenre { BookGenreId = 45, Genre = "War" },
                new BookGenre { BookGenreId = 46, Genre = "Young Adult" }
            };
        }

        public IList<BookFormat> GetDataToSeedBookFormat()
        {
            return new List<BookFormat>()
            {
                new BookFormat { BookFormatId = 1, Format = "Audiobook" },
                new BookFormat { BookFormatId = 2, Format = "E-book" },
                new BookFormat { BookFormatId = 3, Format = "Folio" },
                new BookFormat { BookFormatId = 4, Format = "Hardcover" },
                new BookFormat { BookFormatId = 5, Format = "Paperback" },
                new BookFormat { BookFormatId = 6, Format = "Mass-Market Paperback" },
            };
        }
    }
}
