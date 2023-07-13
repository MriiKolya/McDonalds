using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public partial class ResetPasswordPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel _User;

        public ResetPasswordPageViewModel()
        {
            User = new UserModel();
        }

        [ObservableProperty]
        bool _ActiveInd = false;

        [ObservableProperty]
        bool _TextEx = false;

        [ObservableProperty]
        Color _BorderColor = (Color)App.ColorFromRD["BorderSecondColor"];

        [RelayCommand]
        public async Task GoBack()
        {
            await AppShell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task AutUser()
        {
            ActiveInd = true;
            var countUser = await App.userServices.FindUserByPhone(User);
            if(countUser)
            {
                try
                {
                    App.userServices.SendCode(User);
                    TextEx = false;
                    var tempuser = App.userServices.ResetPasswordOrRegister(User, true);
                    var navigationParameter = new Dictionary<string, object>() { { "User",tempuser } };
                    await AppShell.Current.GoToAsync($"VerificationPage", navigationParameter);

                }
                catch (Exception ex)
                {
                    TextEx = true;
                    BorderColor = (Color)App.ColorFromRD["MainRedColor"];
                }
            }
            else
            {
                BorderColor = (Color)App.ColorFromRD["MainRedColor"];
                TextEx = true;
            }
            ActiveInd = false;
        }
    }
}

