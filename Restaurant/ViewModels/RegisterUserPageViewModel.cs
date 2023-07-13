using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public partial class RegisterUserPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel _User;

        public RegisterUserPageViewModel()
        {
            User = new UserModel();
        }
        [ObservableProperty]
        bool visibleExTextPhone;

        [ObservableProperty]
        bool visibleExTextPassword;

        [ObservableProperty]
        bool visibleExTextName;
        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task RegisterUser()
        {
            CheckPasswordAndName();
            if (VisibleExTextName == false && VisibleExTextPassword == false)
            {
                try
                {
                    App.userServices.SendCode(User);
                    var navigationParameter = new Dictionary<string, object>()
                    {
                        { "User",App.userServices.ResetPasswordOrRegister(User,false)}
                    };
                    await AppShell.Current.GoToAsync($"VerificationPage", navigationParameter);
                }
                catch (Exception ex)
                {
                    await AppShell.Current.DisplayAlert("User is not added", "The phone is not correct ", "OK");
                    App.userServices.DataReset(User);
                }
            }
            else
            {
                await AppShell.Current.DisplayAlert("User is not added", "Wrong phone number or password ", "OK");
                App.userServices.DataReset(User);
            }
            
        }

        private void CheckPasswordAndName()
        {
            if (User.Password == null) VisibleExTextPassword = true;
            else
            {
                if (User.Password.Length < 8) VisibleExTextPassword = true;
                else VisibleExTextPassword = false;
            }
            if (User.Name == null) VisibleExTextName = true;
            else VisibleExTextName = false;

            if (User.Phone == null) VisibleExTextPhone = true;
        }
    }
   
}

