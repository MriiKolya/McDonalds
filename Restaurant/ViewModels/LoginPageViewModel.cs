using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        public LoginPageViewModel() {User = new UserModel();}
        [ObservableProperty]
        bool exText = false;

        [RelayCommand]
        public async Task PrintAll()
        {
            await App.userServices.PrintUsersList();
            var UserCount = await App.userServices.LogIn(User);
            if (UserCount == null)
            {
                Console.WriteLine("User not found");
                ExText = true;
            }
            else
            {
                var navigationParameter = new Dictionary<string, object>() { { "User",UserCount } };
                await AppShell.Current.GoToAsync($"MainPage", navigationParameter);
                ExText = false;
            }
        }
        [RelayCommand]
        public async Task NavToCreaterAccount()
        {
            await AppShell.Current.GoToAsync("RegisterUserPage");
        }
        [RelayCommand]
        public async Task NavToResetPassword()
        {
            await AppShell.Current.GoToAsync("ResetPasswordPage");
        }
    }
}

