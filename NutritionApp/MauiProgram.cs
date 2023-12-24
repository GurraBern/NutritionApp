using AutoMapper;
using CommunityToolkit.Maui;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nutrition.Core;
using NutritionApp.Data;
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

        builder.AddAppSettings();
        builder.RegisterServices();
        builder.RegisterViewModels();
        builder.RegisterPages();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FoodItem, SearchFoodItem>();
            cfg.CreateMap<SearchFoodItem, FoodItem>();
        });

        builder.Services.AddTransient<IMapper>(mapper =>
        {
            return configuration.CreateMapper();
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<INutritionTrackingService, UserNutritionTrackingService>();
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<INutrientFactory, NutrientFactory>();
        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<INutritionService, NutritionService>();
        builder.Services.AddSingleton<INutritionTracker, NutritionTracker>();
        builder.Services.AddSingleton<IDataRepository, LocalDataRepository>();
        builder.Services.AddSingleton<IToastService, ToastService>();
        builder.Services.AddSingleton<NavigationService>();

        builder.Services.AddSingleton<IRestClient>(provider =>
        {
            string apiUrl = builder.Configuration["AppSettings:NutritionApiUrl"];
            return RestClientFactory.CreateRestClient(apiUrl);
        });

        builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = builder.Configuration["AppSettings:FirebaseApiKey"],
            AuthDomain = builder.Configuration["AppSettings:AuthDomain"],
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        }));

        builder.Services.AddSingleton<INutritionApiClient>(serviceProvider =>
        {
            string apiUrl = builder.Configuration["AppSettings:NutritionApiUrl"];
            return new NutritionApiClient(apiUrl);
        });

        builder.Services.AddSingleton<IUserNutritionApiClient>(serviceProvider =>
        {
            var baseUrl = builder.Configuration["AppSettings:UserNutritionApiUrl"];
            return new UserNutritionApiClient(baseUrl);
        });
    }

    private static void RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<FoodDetailViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<NutritionDetailViewModel>();
        builder.Services.AddTransient<AddFoodViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
    }

    private static void RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<FoodDetailPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<NutritionDetailPage>();
        builder.Services.AddTransient<AddFoodPage>();
        builder.Services.AddTransient<SettingsPage>();
    }

    private static void AddAppSettings(this MauiAppBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("MAUI_ENVIRONMENT") ?? "Production";
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"NutritionApp.appsettings.{environment}.json");

        if (stream != null)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);
        }
    }
}