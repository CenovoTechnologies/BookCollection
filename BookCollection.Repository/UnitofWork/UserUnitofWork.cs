using BookCollection.Core;

namespace BookCollection.Repository.UnitofWork
{
    public class UserUnitofWork : BaseUnitofWork
    {
        public void AddNewUser(User user)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Create(user);
                Save();
            }
        }

        public void UpdateUser(User user)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Update(user);
                Save();
            }
        }

        public void DeleteUser(User user)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Delete(user);
                Save();
            }
        }

        public bool Exists(User user)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).Exists(user); ;
            }
        }
    }
}
