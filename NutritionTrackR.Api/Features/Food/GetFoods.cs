using MediatR;
using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Core.Foods.Queries;

namespace NutritionTrackR.Api.Features.Food;

public static class GetFoods
{
	public static void MapGetFoods(this WebApplication app)
	{
		app.MapGet("api/v1/food", async (IMediator mediator) =>
		{
			var filter = new FoodsQueryFilter
			{
				HealthyScore = 10
			};

			var query = new GetFoodsQuery(filter);

			var result = await mediator.Send(query);

			var foods = result.Value.MapFoodResponse();
			
			return Results.Ok(foods);
		});
	}
}