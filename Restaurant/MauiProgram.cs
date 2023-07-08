using Microsoft.Extensions.Logging;
using Restaurant.Page;
using Restaurant.ViewModels;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;

namespace Restaurant;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjUwNTkxOUAzMjMxMmUzMDJlMzBNd3dpTGJkMzJIcUFEUlg4czZCNUNreVpzK3IvSHR0OEpYZU5jYUswTmh3PQ==");
        builder.ConfigureSyncfusionCore();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-ExtraLight.ttf", "PoppinsExtraLight");
                fonts.AddFont("mclawsuit.ttf", "Mclawsuit");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        //Авторизація Смс-код
        builder.Services.AddSingleton<ResetPasswordPage>();
        builder.Services.AddTransient<ResetPasswordPageViewModel>();

        //Верификація
        builder.Services.AddSingleton<VerificationPage>();
        builder.Services.AddTransient<VerificationPageViewModel>();

        //Авторизація
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddTransient<LoginPageViewModel>();

        //Регістрація
        builder.Services.AddSingleton<RegisterUserPage>();
        builder.Services.AddTransient<RegisterUserPageViewModel>();

        //Основна Сторінка
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();


        return builder.Build();
    }
}

