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

        public LoginPageViewModel()
        {
            User = new UserModel();
        }
        [ObservableProperty]
        bool exText = false;

        [RelayCommand]
        public async void PrintAll()
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
                ExText = false;
                var navigationParameter = new Dictionary<string, object>()
                    {
                        { "User",UserCount}
                    };
                await AppShell.Current.GoToAsync($"MainPage", navigationParameter);
            }
            App.userServices.DataReset(User);
        }
        [RelayCommand]
        public async void NavToCreaterAccount()
        {
            await AppShell.Current.GoToAsync("RegisterUserPage");
            App.userServices.DataReset(User);
        }
        [RelayCommand]
        public async void NavToResetPassword()
        {
            await AppShell.Current.GoToAsync("ResetPasswordPage");
            App.userServices.DataReset(User);
        }
        [RelayCommand]
        public async void ShowUser()
        {
            await App.userServices.PrintUsersList();
        }
        [RelayCommand]
        public async void DeletedUser()
        {
            await App.userServices.RemoveAllUser();
        }

    }
}

