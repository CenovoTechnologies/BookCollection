using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Core
{
    public class Author : Person
    {
        [Key]
        public int AuthorId { get; set; }

        public string WikipediaLink { get; set; }

        public string WebsiteLink { get; set; }

        public string SortName { get; set; }

        public string Pseudonym { get; set; }
    }
}
