using CommunityToolkit.Maui;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services;
using NutritionApp.Services.AuthService;
using NutritionApp.Services.NutritionServices;
using RestSharp;
using System.Reflection;

namespace NutritionApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton<IRestClient>(provider =>
        {
            string apiUrl = builder.Configuration["AppSettings:NutritionApiUrl"];
            return RestClientFactory.CreateRestClient(apiUrl);
        });

        var appSettingsPath = "NutritionApp.appsettings.json";
        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MauiProgram)).Assembly;
        var stream = assembly.GetManifestResourceStream(appSettingsPath);
        builder.Configuration.AddJsonStream(stream);

        builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = builder.Configuration["AppSettings:FirebaseApiKey"],
            AuthDomain = builder.Configuration["AppSettings:AuthDomain"],
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        }));

        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<INutrientFactory, NutrientFactory>();
        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<INutritionService, NutritionService>();
        builder.Services.AddSingleton<INutritionTracker, NutritionTrackingService>();
        builder.Services.AddSingleton<INutritionRepository, NutritionRepository>();

        builder.Services.AddSingleton<NavigationService>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<FoodDetailPage>();
        builder.Services.AddTransient<FoodDetailViewModel>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
