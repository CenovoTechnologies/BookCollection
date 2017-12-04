using BookCollection.Repository.Interfaces;

namespace BookCollection.Repository.UnitofWork
{
    public abstract class BaseUnitofWork
    {
        protected ApplicationDbContext DbContext;

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
