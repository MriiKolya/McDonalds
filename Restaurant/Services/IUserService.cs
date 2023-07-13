using System;
using Restaurant.Models;
using Twilio.Rest.Verify.V2.Service;

namespace Restaurant.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsersList();
        Task AddUser(UserModel user);
        Task<int> RemoveUser(UserModel user);
        Task<int> UpdateUser(UserModel user);
        Task<int> RemoveAllUser();
        Task<UserModel> LogIn(UserModel user);
        Task<bool> FindUserByPhone(UserModel user);
        UserModel ResetPasswordOrRegister(UserModel user,bool ResetPassword);
        void DataReset(UserModel user);
    }
}

