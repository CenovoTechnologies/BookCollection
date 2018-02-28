using System;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime DeathDate { get; set; }

        public string BirthPlace { get; set; }

        public string DeathPlace { get; set; }

        public string WikipediaLink { get; set; }

        public string WebsiteLink { get; set; }

        public string Pseudonym { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        public int BookCollectionId { get; set; }

        public BooksCollection BooksCollection { get; set; }
    }
}
