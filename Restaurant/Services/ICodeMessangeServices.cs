using System;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface ICodeMessangeServices
    {
        void SendCode(UserModel user);
        string CheckUser(UserModel user, string code);
    }
}

