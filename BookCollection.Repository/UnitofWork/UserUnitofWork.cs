using BookCollection.Core;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection.Repository.UnitofWork
{
    public class UserUnitofWork : BaseUnitofWork
    {
        public void AddNewUser(User user)
        {
            using (DbContext = new ApplicationDbContext())
            {
                DbContext.Users.Add(user);
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

        public bool DeleteUser(User user)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var found = DbContext.Users.Find(user);
                if (found == null)
                {
                    return false;
                }
                DbContext.Users.Remove(found);
                Save();
                return true;
            }
        }

        public bool DeleteUserById(int id)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var found = DbContext.Users.Find(id);
                if (found == null)
                {
                    return false;
                }
                DbContext.Users.Remove(found);
                Save();
                return true;
            }
        }

        public bool Exists(User user)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).Exists(user);
            }
        }

        public bool ExistsById(int id)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return DbContext.Users.Count(e => e.UserId == id) > 0;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).GetAll<User>();
            }
        }

        public User GetUser(int id)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).GetById<User>(id);
            }
        }
    }
}
