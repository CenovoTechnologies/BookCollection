using System.Linq;
using BookCollection.Core;
using BookCollection.Core.Interfaces;
using BookCollection.Repository.Interfaces;

namespace BookCollection.Service
{
    public class UserService : IUserService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;

        public UserService(IReadOnlyRepository readOnlyRepository, IRepository repository)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
        }

        public bool CheckIfUserExists(User user)
        {
            return _readOnlyRepository.Exists<User>(x => x.Email.Equals(user.Email));
        }

        public void AddNewUser(User user)
        {
            _repository.Create(user);
            _repository.SaveAsync();
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
            _repository.SaveAsync();
        }

        public bool DeleteUser(User user)
        {
            _repository.Delete(user);
            _repository.SaveAsync();
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
    }
}
