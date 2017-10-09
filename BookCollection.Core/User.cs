using System;
using System.ComponentModel.DataAnnotations;

namespace BookCollection.Core
{
    public class User : Person
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        private string Password { get; set; }

        private Guid LicenseKey { get; set; }
    }
}
