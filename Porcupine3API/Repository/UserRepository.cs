using Microsoft.EntityFrameworkCore;
using Porcupine3API.DBContexts;
using Porcupine3API.Models;
using System;

namespace Porcupine3API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectContext _dbContext;

        public UserRepository(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add try catches for request handling
        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            _dbContext.Users.Remove(user);
            Save();
        }

        public UserM GetUserByID(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public IEnumerable<UserM> GetUsers()
        {
            var userList = _dbContext.Users.ToList();
            return userList;
        }

        public void CreateUser(UserM user)
        {
            _dbContext.Users.Add(user);
            Save();
        }

        public void UpdateUser(UserM user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}