using Porcupine3API.Models;
using System.Collections.Generic;

namespace Porcupine3API.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserM> GetUsers();
        UserM GetUserByID(int id);
        void CreateUser(UserM user);
        void DeleteUser(int id);
        void UpdateUser(UserM user);
        void Save();
    }
}
