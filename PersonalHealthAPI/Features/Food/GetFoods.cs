using NutritionTrackR.Core.Food.Queries;
using MediatR;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Shared;

namespace PersonalHealthAPI.Features.Food;

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

			var t = FoodResponse.MapResponse(result.Value);
			
			var response = new ApiResponse<FoodResponse>(true, Error.None, t);

			return Results.Ok(response);
		});
	}
}