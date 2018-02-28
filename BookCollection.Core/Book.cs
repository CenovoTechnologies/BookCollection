using System;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        public int CollectionId { get; set; }

        public BooksCollection Collection { get; set; }

        public string Isbn { get; set; }

        public int BookGenreId { get; set; }

        public BookGenre BookGenre { get; set; }

        public int BookFormatId { get; set; }

        public BookFormat BookFormat { get; set; }

        public int? NumberOfPages { get; set; }

        public string LocClassification { get; set; }

        public string Dewey { get; set; }

        public string Publisher { get; set; }

        public DateTime PublisherDate { get; set; }

        public string Plot { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
