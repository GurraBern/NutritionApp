using Microsoft.Extensions.Options;
using NutritionTrackR.Web.Components.Services;
using System.ComponentModel.DataAnnotations;
using NutritionTrackR.Web.Configuration;

namespace NutritionTrackR.Web.Extensions;

public static class HttpClientExtensions
{
	public static void SetupNutritionTrackRHttpClient(this WebApplicationBuilder builder)
	{
		builder.Services
			.AddOptions<NutritionTrackRApiSettings>()
			.Bind(builder.Configuration.GetSection(nameof(NutritionTrackRApiSettings)))
			.ValidateDataAnnotations();

		builder.SetupHttpClient(nameof(FoodListAdapter));
		builder.SetupHttpClient(nameof(NutritionGoalAdapter));
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
