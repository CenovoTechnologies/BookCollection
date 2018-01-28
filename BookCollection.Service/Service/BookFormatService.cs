using BookCollection.Core;
using BookCollection.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection.Service.Service
{
    public class BookFormatService : Service
    {
        private ApplicationDbContext db;

        public IList<BookFormat> GetAllBookFormats()
        {
            using (db = new ApplicationDbContext())
            {
                return db.BookFormat.ToList();
            }
        }

        public BookFormat GetBookFormatById(int bookFormatId)
        {
            using (db = new ApplicationDbContext())
            {
                return db.BookFormat.FindAsync(bookFormatId).Result;
            }
        }
    }
}