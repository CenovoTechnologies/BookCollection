using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCollection.Core
{
    public class User : Entity<Int32>
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        public ICollection<BooksCollection> BookCollections { get; set; }

        private string Password { get; set; }

        private Guid LicenseKey { get; set; }
    }
}
