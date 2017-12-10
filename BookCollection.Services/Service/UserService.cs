using BookCollection.Core;
using BookCollection.Repository.UnitofWork;

namespace BookCollection.Services.Service
{
    public class UserService : Service
    {
        public bool CheckIfUserExistsInDatabase(User user)
        {
            return new UserUnitofWork().Exists(user);
        }

        public void AddNewUserToTheDatabase(User user)
        {
            new UserUnitofWork().AddNewUser(user);
        }

        public void UpdateUserInTheDatabase(User user)
        {
            new UserUnitofWork().UpdateUser(user);
        }
    }
}
