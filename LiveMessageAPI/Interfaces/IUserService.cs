using System;
using LiveMessageAPI.Models;

namespace LiveMessageAPI.Interfaces
{
	public interface IUserService
	{
        void CreateUser(UserModel user);
        UserModel GetUserById(int id);
        List<UserModel> GetAllUsers();
    }
}

