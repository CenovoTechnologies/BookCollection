using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCollection.Core
{
    public class BooksCollection : Entity<int>
    {
        public string CollectionName { get; set; }

        public ICollection<Book> Collection { get; set; }

        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
    }
}
