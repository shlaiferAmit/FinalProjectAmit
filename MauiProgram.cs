using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FinalProjectAmit.Views;
using FinalProjectAmit.ViewModels;

namespace FinalProjectAmit;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // 🔥 רישום דפים
        builder.Services.AddTransient<SignInPage>();
        builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AdminPage>();
        builder.Services.AddTransient<UserListPage>();
        builder.Services.AddTransient<UserDetailsPage>();

        // 🔥 רישום ViewModels
        builder.Services.AddTransient<SignInPageViewModel>();
        builder.Services.AddTransient<SignUpPageViewModel>();
        builder.Services.AddTransient<UsersListViewModel>();
        builder.Services.AddTransient<AdminPageViewModel>();
        builder.Services.AddTransient<UserDetailsPageViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}