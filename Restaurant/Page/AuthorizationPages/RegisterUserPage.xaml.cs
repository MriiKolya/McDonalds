using Restaurant.ViewModels;

namespace Restaurant.Page;

public partial class RegisterUserPage : ContentPage
{
    public RegisterUserPage(RegisterUserPageViewModel Phone)
    {
        InitializeComponent();
        BindingContext = Phone;
    }
}
