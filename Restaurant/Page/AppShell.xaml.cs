using Restaurant.Page;
using Restaurant.Page.AuthorizationPages;

namespace Restaurant;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ResetPasswordPage), typeof(ResetPasswordPage));
        Routing.RegisterRoute(nameof(VerificationPage), typeof(VerificationPage));
        Routing.RegisterRoute(nameof(RegisterUserPage), typeof(RegisterUserPage));
        Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}

