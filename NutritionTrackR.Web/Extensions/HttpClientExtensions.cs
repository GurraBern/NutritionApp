using Microsoft.Extensions.Options;
using NutritionTrackR.Web.Configuration;
using NutritionTrackR.Web.Services;

namespace NutritionTrackR.Web.Extensions;

public static class HttpClientExtensions
{
	public static void SetupNutritionTrackRHttpClient(this WebApplicationBuilder builder)
	{
		builder.Services
			.AddOptions<NutritionTrackRApiSettings>()
			.Bind(builder.Configuration.GetSection(nameof(NutritionTrackRApiSettings)))
			.ValidateDataAnnotations();
		
		builder.SetupAdapter<FoodListAdapter>();
		builder.SetupAdapter<NutritionTargetAdapter>();
		builder.SetupAdapter<WeightAdapter>();
		builder.SetupAdapter<FoodAdapter>();
	}

	private static void SetupAdapter<T>(this WebApplicationBuilder builder) where T : class
	{
		builder.SetupHttpClient(typeof(T).Name);
		builder.Services.AddScoped<T>();
	}
	
	private static void SetupHttpClient(this WebApplicationBuilder builder, string name)
	{
		builder.Services.AddHttpClient(name, (serviceProvider, httpClient) =>
		{
			var settings = serviceProvider.GetRequiredService<IOptions<NutritionTrackRApiSettings>>().Value;
			httpClient.BaseAddress = new Uri(settings.BaseAddress);
		});
	}
}
