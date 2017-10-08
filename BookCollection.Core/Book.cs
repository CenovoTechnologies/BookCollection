using BookCollection.Core.Enums;
using BookCollection.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Core
{
    public class Book : ICollectible
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public ICollection<Author> Authors { get; set; }

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
