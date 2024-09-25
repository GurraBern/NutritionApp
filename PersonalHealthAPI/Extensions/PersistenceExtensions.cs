using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.NutrientTracking;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Persistence;
using NutritionTrackR.Persistence.Repositories;

namespace PersonalHealthAPI.Extensions;

public static class PersistenceExtensions
{

	public static void SetupPersistence(this WebApplicationBuilder builder)
	{
		builder.SetupEfCore();
		
		builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
		builder.Services.AddScoped<IFoodRepository, FoodRepository>();
		builder.Services.AddScoped<INutritionDayRepository, NutritionDayRepository>();
	}

	private static void SetupEfCore(this WebApplicationBuilder builder)
	{
		builder.Services
			.AddOptions<DatabaseSettings>()
			.Bind(builder.Configuration.GetSection(nameof(DatabaseSettings)))
			.ValidateDataAnnotations();

		builder.Services.AddDbContext<NutritionDbContext>((serviceProvider, options) =>
		{
			var settings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>();
			options.UseMongoDB(settings.Value.ConnectionString, "NutritionTrackR");
		});
	}
}