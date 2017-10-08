﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Core
{
    public abstract class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
