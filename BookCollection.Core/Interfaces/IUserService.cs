namespace BookCollection.Core.Interfaces
{
    public interface IUserService
    {
        bool CheckIfUserExists(User user);

        void AddNewUser(User user);

        void UpdateUser(User user);

        bool DeleteUser(User user);

        User GetUserById(int id);

        User GetUserByEmail(string email);
    }
}
