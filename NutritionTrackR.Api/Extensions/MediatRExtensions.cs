using MediatR;
using NutritionTrackR.Contracts.BodyMeasurement;
using NutritionTrackR.Core.BodyMeasurements.Events;
using NutritionTrackR.Core.BodyMeasurements.Queries;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.Commands;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.Nutrition.Target.Commands;
using NutritionTrackR.Core.Nutrition.Tracking.Commands;
using NutritionTrackR.Core.Nutrition.Tracking.Queries;
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
			.AddScoped<IRequestHandler<CreateFoodCommand, Result>, CreateFoodHandler>()
			.AddScoped<IRequestHandler<LogFood, Result>, LogFoodCommandHandler>()
			.AddScoped<IRequestHandler<GetLoggedFoodsQuery, LoggedFoodResponse>, GetNutritionDays>()
			.AddScoped<IRequestHandler<GetFoodsQuery, Result<IEnumerable<Food>>>, GetFoodsHandler>()
			.AddScoped<IRequestHandler<CreateNutritionTargetCommand, Result>, CreateNutritionTarget>()
			.AddScoped<IRequestHandler<GetBodyWeightDataQuery, IEnumerable<WeightDto>>, GetCurrentBodyWeightDataQueryHandler>()
			;
	}
}