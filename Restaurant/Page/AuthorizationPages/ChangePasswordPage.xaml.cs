using Restaurant.ViewModels;

namespace Restaurant.Page.AuthorizationPages;

public partial class ChangePasswordPage : ContentPage
{
    public ChangePasswordPage(ChangePasswordPageViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }

    void NewPasswordEntry(System.Object sender, System.EventArgs e)
    {
        if (NewPassword.Text.Length < 8) NewPassword.HasError = true;
        else NewPassword.HasError = false;
    }

    void NewConfirmPasswordEntry(System.Object sender, System.EventArgs e)
    {
        if (ConfirmNewPassword.Text.Length < 8) ConfirmNewPassword.HasError = true;
        else ConfirmNewPassword.HasError = false;
    }
}
