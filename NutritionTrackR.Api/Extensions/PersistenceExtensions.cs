using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Nutrition.Target;
using NutritionTrackR.Core.Nutrition.Tracking;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Persistence;
using NutritionTrackR.Persistence.Repositories;

namespace NutritionTrackR.Api.Extensions;

public static class PersistenceExtensions
{

	public static void SetupPersistence(this WebApplicationBuilder builder)
	{
		builder.SetupEfCore();
		builder.Services.AddScoped<INutritionDbContext, NutritionDbContext>();
		
		builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
		builder.Services.AddScoped<INutritionDayRepository, NutritionDayRepository>();
		builder.Services.AddScoped<INutritionTargetRepository, NutritionTargetRepository>();
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