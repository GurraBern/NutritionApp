using AutoMapper;
using CommunityToolkit.Maui;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microcharts.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nutrition.Core;
using NutritionApp.Components;
using NutritionApp.Data;
using NutritionApp.Data.Dto;
using NutritionApp.Data.Services;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices;
using RestSharp;
using Syncfusion.Maui.Core.Hosting;
using System.Reflection;

namespace NutritionApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMicrocharts()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("UbuntuSans-ExtraBold.ttf", "UbuntuSansExtraBold");
                fonts.AddFont("UbuntuSans-Regular.ttf", "UbuntuSansRegular");
            });

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
        builder.Services.AddTransient<INutritionTrackingService, NutritionTrackingService>();
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<INutrientFactory, NutrientFactory>();
        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<INutritionService, NutritionService>();
        builder.Services.AddSingleton<INutritionTracker, NutritionTracker>();
        builder.Services.AddSingleton<IDataRepository, LocalDataRepository>();
        builder.Services.AddSingleton<IToastService, ToastService>();
        builder.Services.AddSingleton<NavigationService>();
        builder.Services.AddTransient<IMeasurementsService, MeasurementsService>();
        builder.Services.AddScoped<UserDetails>();



        //builder.Services.AddSingleton<IRestClient>(provider =>
        //{
        //    string apiUrl = builder.Configuration["AppSettings:NutritionApiUrl"];
        //    return CreateRestClient(apiUrl);
        //});

        builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = builder.Configuration["AppSettings:FirebaseApiKey"],
            AuthDomain = builder.Configuration["AppSettings:AuthDomain"],
            Providers =
            [
                new EmailProvider()
            ]
        }));

        //builder.Services.AddSingleton<IRestClient>(provider =>
        //{
        //    string apiUrl = builder.Configuration["AppSettings:NutritionApiUrl"];
        //    return CreateRestClient(apiUrl);
        //});

        builder.Services.AddSingleton<INutritionApiClient>(serviceProvider =>
        {
            string nutritionApiUrl = builder.Configuration["AppSettings:NutritionApiUrl"];
            var nutritionRestClient = new RestClient(nutritionApiUrl);
            return new NutritionApiClient(nutritionRestClient);
        });


        //TODO move to separate method: API Clients
        //string personalHealthApiUrl = builder.Configuration["AppSettings:PersonalHealthApiUrl"];
        //var personalHealthApiClient = new RestClient(personalHealthApiUrl);

        //builder.Services.AddTransient<IPersonalHealthApiClient<NutritionDay>>(serviceProvider =>
        //{
        //    return new PersonalHealthApiClient<NutritionDay>(personalHealthApiClient);
        //});

        //builder.Services.AddTransient<IPersonalHealthApiClient<BodyMeasurements>>(serviceProvider =>
        //{
        //    return new PersonalHealthApiClient<BodyMeasurements>(personalHealthApiClient);
        //});



        var personalHealthApiClient = new RestClient(builder.Configuration["AppSettings:PersonalHealthApiUrl"]);
        builder.RegisterPersonalHealthApiClient<NutritionDay>(personalHealthApiClient);
        builder.RegisterPersonalHealthApiClient<BodyMeasurements>(personalHealthApiClient);


        //builder.Services.AddTransient<IUserMeasurementsApiClient, UserMeasurementsApiClient>();

        //builder.Services.AddSingleton<INutritionApiClient>(serviceProvider =>
        //{
        //    string apiUrl = builder.Configuration["AppSettings:NutritionApiUrl"];
        //    return new NutritionApiClient(apiUrl);
        //});


        //builder.Services.AddSingleton<IUserNutritionApiClient>(serviceProvider =>
        //{
        //    var baseUrl = builder.Configuration["AppSettings:UserNutritionApiUrl"];
        //    var restClient = new RestClient(baseUrl);
        //    return new UserNutritionApiClient(restClient);
        //});

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["AppSettings:SyncFusion"]);
    }

    private static void RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<FoodDetailViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<NutritionDetailViewModel>();
        builder.Services.AddTransient<AddFoodViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<MealDetailViewModel>();
        builder.Services.AddTransient<UserPagesViewModel>();
        builder.Services.AddTransient<ProgressViewModel>();
        builder.Services.AddTransient<AddWeightViewModel>();
    }

    private static void RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<FoodDetailPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<NutritionDetailPage>();
        builder.Services.AddTransient<AddFoodPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<MealDetailView>();
        builder.Services.AddTransient<UserPage>();
        builder.Services.AddTransient<ProgressPage>();
        builder.Services.AddTransient<AddWeightPage>();
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

    private static IRestClient CreateRestClient(string baseUrl)
    {
        var options = new RestClientOptions(baseUrl);
        return new RestClient(options);
    }

    private static void RegisterPersonalHealthApiClient<T>(this MauiAppBuilder builder, IRestClient restClient)
    {
        builder.Services.AddTransient<IPersonalHealthApiClient<T>>(serviceProvider =>
        {
            return new PersonalHealthApiClient<T>(restClient);
        });
    }
}