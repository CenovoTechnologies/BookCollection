using BookCollection.Core;
using BookCollection.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Services
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
