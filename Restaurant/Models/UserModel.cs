using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace Restaurant.Models
{
    public partial class UserModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }

        [ObservableProperty]
        public string _Name = "";

        [ObservableProperty]
        public string _Phone = "";

        [ObservableProperty]
        public string _Password = "";


        //Параметр для того что бы востановить пароль
        [Ignore]
        public bool IsResetPassword { get; set; } = false;
    }
}

