using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices;
using NutritionApp.Services.NutritionServices.NutritionService;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;
using RestSharp;
using System.Reflection;

namespace NutritionApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
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

        builder.Services.AddSingleton<INutritionService, NutritionService>();
        builder.Services.AddSingleton<INutritionTracker, NutritionTrackingService>();
        builder.Services.AddSingleton<INutrientSettings, NutrientSettings>();

        builder.Services.AddSingleton<NavigationService>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<NutritionDetailViewModel>();
        builder.Services.AddSingleton<NutritionDetailPage>();

        builder.Services.AddTransient<FoodDetailPage>();
        builder.Services.AddTransient<FoodDetailViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
