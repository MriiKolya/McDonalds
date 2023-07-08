using Restaurant.ViewModels;

namespace Restaurant.Page;

public partial class VerificationPage : ContentPage
{
    public VerificationPage(VerificationPageViewModel Phone)
    {
        InitializeComponent();
        BindingContext = Phone;
    }
}