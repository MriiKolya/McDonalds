using Restaurant.DataBase;
using Restaurant.ViewModels;

namespace Restaurant;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}


