using System;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class BooksCollection
    {
        public int CollectionId { get; set; }

        public string CollectionName { get; set; }

        public ICollection<Book> Collection { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}
