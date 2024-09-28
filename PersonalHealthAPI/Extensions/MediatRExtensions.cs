using MediatR;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.Commands;
using NutritionTrackR.Core.Food.Queries;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;

namespace PersonalHealthAPI.Extensions;

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
			.AddScoped<IRequestHandler<AddFoodEntryCommand, Result>, AddFoodEntryCommandHandler>()
			.AddScoped<IRequestHandler<GetFoodsQuery, Result<IEnumerable<Food>>>, GetFoodsHandler>();
	}
}