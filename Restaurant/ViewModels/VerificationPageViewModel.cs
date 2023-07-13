using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    [QueryProperty("User", "User")]
    public partial class VerificationPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel _User;

        [ObservableProperty]
        bool _TextEx = false;

        [ObservableProperty]
        string uicode ="";

        [ObservableProperty]
        string timer = "Send the code again";
        [ObservableProperty]
        bool isEnableTimer = true;

        [ObservableProperty]
        bool _ExLabel = false;

        [ObservableProperty]
        string _ExLabelText = "Incorrect code, try again";

        [ObservableProperty]
        Color _BorderColor = (Color)App.ColorFromRD["BorderSecondColor"];

        [RelayCommand]
        async Task SendCodeAgain()
        {
            App.userServices.SendCode(User);
            TimeSpan time = TimeSpan.FromMinutes(2);
            while (time.TotalSeconds > 0)
            {
                time = time.Subtract(TimeSpan.FromSeconds(1));
                Timer = $"{time.Minutes} : {time.Seconds:00}";
                await Task.Delay(TimeSpan.FromSeconds(1));
                IsEnableTimer = false;
            }
            IsEnableTimer = true;
            timer = "Send the code again";
        }
        [RelayCommand]
        async Task SendVerification()
        {
            //var navigationParameter = new Dictionary<string, object>() { { "User", User } };
            //await AppShell.Current.GoToAsync($"ChangePasswordPage", navigationParameter);
            try
            {
                string code = Uicode.Replace(" ", string.Empty);
                string verification = App.userServices.CheckUser(User, Uicode);
                if (verification == "approved")
                {
                    if (User.IsResetPassword == false)
                    {
                        await userIsRegistered();
                        await App.userServices.AddUser(User);
                    }
                    else
                    {
                        var navigationParameter = new Dictionary<string, object>() { { "User", User } };
                        await AppShell.Current.GoToAsync($"ChangePasswordPage", navigationParameter);
                        ExLabel = false;
                    }
                }
                else
                {
                    ExLabel = true;
                    Uicode = "";
                }
            }
            catch (Exception ex)
            {
                BorderColor = (Color)App.ColorFromRD["MainRedColor"];
                ExLabel = true;
                Console.WriteLine("ошибка");
                Uicode = "";
            }
        }
        private async Task userIsRegistered()
        {   
            var UserCount = await App.userServices.FindUserByPhone(User);
            if (UserCount == false)
            {
                Console.WriteLine("Пользователь нету с таким номером телефона");
                await AppShell.Current.GoToAsync("//LoginPage");
                BorderColor = (Color)App.ColorFromRD["BorderSecondColor"];
                Uicode = "";
                ExLabel = false;
            }
            else
            {
                Console.WriteLine("Пользователь уже с таким номером телефона уже есть в БД");
                await AppShell.Current.GoToAsync($"//LoginPage");
                BorderColor = (Color)App.ColorFromRD["BorderSecondColor"];
                ExLabel = true;
                Uicode = "";
            }
        }
        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task GoLogin()
        {
            await AppShell.Current.GoToAsync("//LoginPage");
        }
    }
}


