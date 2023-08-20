using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using NutritionApp.MVVM.Viewmodels;
using NutritionApp.Services;
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

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
