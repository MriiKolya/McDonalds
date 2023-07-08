using Restaurant.DataBase;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.ViewModels;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.Inputs;

namespace Restaurant.Page;

public partial class ResetPasswordPage : ContentPage
{
    public ResetPasswordPage(ResetPasswordPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Console.WriteLine("click");
    }
}
