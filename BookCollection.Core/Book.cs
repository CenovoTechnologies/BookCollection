using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCollection.Core
{
    public class Book : Entity<int>
    {

        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public ICollection<Author> Authors { get; set; }

        public int CollectionId { get; set; }

        public BooksCollection Collection { get; set; }

        public string Isbn { get; set; }

        public BookGenre Genre { get; set; }

        public BookFormat Format { get; set; }

        public int? NumberOfPages { get; set; }

        public string LocClassification { get; set; }

        public string Dewey { get; set; }

        public string Publisher { get; set; }

        public DateTime PublisherDate { get; set; }

        public string Plot { get; set; }

    }
}
