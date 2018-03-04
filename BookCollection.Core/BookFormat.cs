﻿
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class BookFormat
    {
        public int BookFormatId { get; set; }
        public string Format { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
