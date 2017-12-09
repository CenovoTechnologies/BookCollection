using System;
using System.Collections;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class BooksCollection : Entity<int>
    {
        public string CollectionName { get; set; }

        public ICollection<Book> Collection { get; set; }
    }
}
