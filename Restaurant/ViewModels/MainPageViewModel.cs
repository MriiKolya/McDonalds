using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    [QueryProperty("User", "User")]
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;


        [RelayCommand]
        void showUser()
        {
            Console.WriteLine(User.Name);
            Console.WriteLine(User.Password);
            Console.WriteLine(User.Phone);
        }
    }
}

