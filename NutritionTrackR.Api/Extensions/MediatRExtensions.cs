using MediatR;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.Commands;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.NutrientTracking.Commands;
using NutritionTrackR.Core.NutrientTracking.Queries;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Api.Extensions;

public static class MediatRExtensions
{
	public static void SetupHandlersAndMediatR(this WebApplicationBuilder builder)
	{
		builder.Services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(typeof(MediatRMarker).Assembly);
		});

		builder.Services
			.AddScoped<IRequestHandler<CreateFoodCommand, Result>, CreateFoodCommandHandler>()
			.AddScoped<IRequestHandler<LogFoodCommand, Result>, LogFoodCommandHandler>()
			.AddScoped<IRequestHandler<GetLoggedFoodsQuery, LoggedFoodResponse>, GetNutritionDaysHandler>()
			.AddScoped<IRequestHandler<GetFoodsQuery, Result<IEnumerable<Food>>>, GetFoodsHandler>();
	}
}