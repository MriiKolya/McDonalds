
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    [QueryProperty("User", "User")]
    public partial class ChangePasswordPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string _EnterPassword;

        [RelayCommand]
        async Task GoLogin()
        {
            await AppShell.Current.GoToAsync("//LoginPage");
        }

        [RelayCommand]
        async Task UpdatePassword()
        {
            if(User.Password == EnterPassword)
            {
                try
                {
                    await App.userServices.UpdateUser(User);
                    await AppShell.Current.GoToAsync("//LoginPage");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ошибка");
                }
            }
            else
            {
                Console.WriteLine("lox");
            }
            
        }

    }
}

