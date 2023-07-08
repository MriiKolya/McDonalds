using System.Linq;
using Restaurant.DataBase;
using Restaurant.Services;

namespace Restaurant;

public partial class App : Application
{
    public static UserServices userServices = new UserServices();
    public static ResourceDictionary ColorFromRD = new ResourceDictionary();
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
        ColorFromRD = Theme;
    }
}

