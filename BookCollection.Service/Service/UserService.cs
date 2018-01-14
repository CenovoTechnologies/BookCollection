using BookCollection.Core;
using BookCollection.Repository.UnitofWork;
using System;
using System.Collections.Generic;

namespace BookCollection.Service.Service
{
    public class UserService : Service
    {
        private UserUnitofWork work = new UserUnitofWork();

        public bool CheckIfUserExists(User user)
        {
            return work.Exists(user);
        }

        public bool CheckIfUserExistsById(int id)
        {
            return work.ExistsById(id);
        }

        public void AddNewUser(User user)
        {
            work.AddNewUser(user);
        }

        public void UpdateUser(User user)
        {
            work.UpdateUser(user);
        }

        public bool DeleteUser(User user)
        {
            return work.DeleteUser(user);
        }

        public bool DeleteUserById(int id)
        {
            return work.DeleteUserById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return work.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return work.GetUser(id);
        }

        public User GetUserByEmail(string email)
        {
            return work.GetUserByEmail(email);
        }
    }
}
