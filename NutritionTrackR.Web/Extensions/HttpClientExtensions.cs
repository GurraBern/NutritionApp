using Microsoft.Extensions.Options;
using NutritionTrackR.Web.Components.Services;
using System.ComponentModel.DataAnnotations;

namespace NutritionTrackR.Web.Extensions;

public static class HttpClientExtensions
{
	public static void SetupNutritionTrackRHttpClient(this WebApplicationBuilder builder)
	{
		builder.Services
			.AddOptions<NutritionTrackRApiSettings>()
			.Bind(builder.Configuration.GetSection(nameof(NutritionTrackRApiSettings)))
			.ValidateDataAnnotations();

		builder.Services.AddHttpClient(nameof(FoodListAdapter), (serviceProvider, httpClient) =>
		{
			var settings = serviceProvider.GetRequiredService<IOptions<NutritionTrackRApiSettings>>().Value;
			httpClient.BaseAddress = new Uri(settings.BaseAddress);
		});
	}
}

public class NutritionTrackRApiSettings
{
	[Required]
	public string BaseAddress { get; set; }
}