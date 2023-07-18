using System;
using LiveMessageAPI.Data;
using LiveMessageAPI.Interfaces;
using LiveMessageAPI.Models;

namespace LiveMessageAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(UserModel user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public UserModel GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<UserModel> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}

