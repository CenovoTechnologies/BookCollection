using BookCollection.Core;
using BookCollection.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection.Service.Service
{
    public class BookGenreService : Service
    {
        private ApplicationDbContext db;

        public IList<BookGenre> GetAllBookGenres()
        {
            using (db = new ApplicationDbContext())
            {
                return db.BookGenre.ToList();
            }
        }

        public BookGenre GetBookGenreById(int bookGenreId)
        {
            using (db = new ApplicationDbContext())
            {
                return db.BookGenre.FindAsync(bookGenreId).Result;
            }
        }
    }
}