using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCollection.Core;
using BookCollection.Repository;
using BookCollection.Repository.UnitofWork;

namespace BookCollection.Services
{
    public class AuthorService : Service
    {
        public bool CheckIfAuthorExists(Author author)
        {
            return new AuthorUnitofWork().Exists(author);
        }
    }
}
