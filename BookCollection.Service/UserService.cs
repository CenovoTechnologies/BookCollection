using System;
using System.Linq;
using BookCollection.Core;
using BookCollection.Core.Interfaces;
using BookCollection.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookCollection.Service
{
    public class UserService : IdentityUser, IUserService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IReadOnlyRepository readOnlyRepository, IRepository repository, IPasswordHasher<User> passwordHasher)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public bool CheckIfUserExists(User user)
        {
            return _readOnlyRepository.Exists<User>(x => x.Email.Equals(user.Email));
        }

        public void AddNewUser(User user, string password)
        {
            user.CreatedDate = DateTime.UtcNow;
            user.ModifiedDate = DateTime.UtcNow;
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            _repository.Create(user);
            _repository.Save();
        }

        public void UpdateUser(User user)
        {
            user.ModifiedDate = DateTime.UtcNow;
            _repository.Update(user);
            _repository.Save();
        }

        public bool DeleteUser(User user)
        {
            _repository.Delete(user);
            _repository.Save();
            return true;
        }

        public User GetUserById(int id)
        {
            return _readOnlyRepository.GetById<User>(id);
        }

        public User GetUserByEmail(string email)
        {
            return _readOnlyRepository.Get<User>(x => x.Email.Equals(email)).FirstOrDefault();
        }

        public bool SignUserInWithPassword(User user, string password)
        {
            var passwordHash = _passwordHasher.HashPassword(user, password);
            return passwordHash.Equals(user.PasswordHash);
        }
    }
}
