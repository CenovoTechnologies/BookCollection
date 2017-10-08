using System;

namespace BookCollection.Core
{
    public abstract class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime DeathDate { get; set; }

        public String BirthPlace { get; set; }

        public String DeathPlace { get; set; }
    }
}
