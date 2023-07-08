using Restaurant.ViewModels;

namespace Restaurant.Page;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        
    }

    void PasswordEntry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        PasswordEntry.HasError = false;
    }

    void PhonedEntry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        PhoneEntry.HasError = false;
    }
}
