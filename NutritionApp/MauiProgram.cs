using CommunityToolkit.Maui;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services;
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

        ConfigureAppSettings(builder);
        RegisterServices(builder.Services, builder.Configuration);
        RegisterViewModels(builder.Services);
        RegisterPages(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void ConfigureAppSettings(MauiAppBuilder builder)
    {
        var appSettingsPath = "NutritionApp.appsettings.json";
        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MauiProgram)).Assembly;
        var stream = assembly.GetManifestResourceStream(appSettingsPath);
        builder.Configuration.AddJsonStream(stream);
    }

    private static void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddTransient<INutritionTrackingService, NutritionTrackingService>();
        serviceCollection.AddSingleton<IAuthService, AuthService>();
        serviceCollection.AddSingleton<INutrientFactory, NutrientFactory>();
        serviceCollection.AddSingleton<ISettingsService, SettingsService>();
        serviceCollection.AddSingleton<INutritionService, NutritionService>();
        serviceCollection.AddSingleton<INutritionTracker, NutritionTracker>();
        serviceCollection.AddSingleton<NavigationService>();

        serviceCollection.AddSingleton<IRestClient>(provider =>
        {
            string apiUrl = configuration["AppSettings:NutritionApiUrl"];
            return RestClientFactory.CreateRestClient(apiUrl);
        });

        serviceCollection.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = configuration["AppSettings:FirebaseApiKey"],
            AuthDomain = configuration["AppSettings:AuthDomain"],
            Providers = new FirebaseAuthProvider[]
        {
                new EmailProvider()
        }
        }));

        serviceCollection.AddSingleton<INutritionApiClient>(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var baseUrl = configuration["AppSettings:UserNutritionApiUrl"];
            return new NutritionApiClient(baseUrl);
        });
    }

    private static void RegisterViewModels(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<MainViewModel>();
        serviceCollection.AddTransient<FoodDetailViewModel>();
        serviceCollection.AddTransient<LoginViewModel>();
    }

    private static void RegisterPages(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<MainPage>();
        serviceCollection.AddTransient<FoodDetailPage>();
        serviceCollection.AddTransient<LoginPage>();
    }
}
