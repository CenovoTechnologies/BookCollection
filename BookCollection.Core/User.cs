using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Core
{
    public class User : Person
    {
        [Key]
        public int UserId { get; set; }
    }
}
