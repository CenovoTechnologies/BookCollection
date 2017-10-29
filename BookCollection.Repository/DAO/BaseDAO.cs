using BookCollection.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Repository.DAO
{
    public abstract class BaseDAO
    {
        protected ApplicationDbContext dbContext;

        public IRepository RetrieveRepository(ApplicationDbContext dbContext)
        {
            return new CollectionRepository<ApplicationDbContext>(dbContext);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
