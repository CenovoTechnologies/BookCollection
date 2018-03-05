using System;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class BooksCollection
    {
        public int CollectionId { get; set; }

        public string CollectionName { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<Author> Authors { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
