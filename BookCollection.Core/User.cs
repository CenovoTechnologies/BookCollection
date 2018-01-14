using System;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        public ICollection<BooksCollection> BookCollections { get; set; }

        private string Password { get; set; }

        private Guid LicenseKey { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime UpdatedDate { get; set; }
    }
}
