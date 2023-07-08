using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    [QueryProperty("User", "User")]
    public partial class ResetPasswordPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel _User;

        public ResetPasswordPageViewModel()
        {
            User = new UserModel();
        }

        [ObservableProperty]
        bool _TextEx = false;

        [ObservableProperty]
        Color _BorderColor = (Color)App.ColorFromRD["BorderSecondColor"];

        [RelayCommand]
        public async void GoBack()
        {
            await AppShell.Current.GoToAsync("..");
            App.userServices.DataReset(User);
        }

        [RelayCommand]
        public async void AutUser()
        {
            await App.userServices.PrintUsersList();
            var countUser = App.userServices.FindUserByPhone(User.Phone);
            if(countUser != null)
            {
                try
                {
                    App.userServices.SendCode(User);
                    TextEx = false;
                    var tempuser = App.userServices.ResetPasswordOrRegister(User, true);
                    BorderColor = (Color)App.ColorFromRD["BorderSecondColor"];
                    var navigationParameter = new Dictionary<string, object>()
                    {
                        { "User",tempuser}
                    };
                    await AppShell.Current.GoToAsync($"VerificationPage", navigationParameter);
                }
                catch (Exception ex)
                {
                    TextEx = true;
                    BorderColor = (Color)App.ColorFromRD["MainRedColor"];
                    App.userServices.DataReset(User);
                }
            }
            else
            {
                TextEx = true;
                App.userServices.DataReset(User);
            }
            
        }
    }
}

