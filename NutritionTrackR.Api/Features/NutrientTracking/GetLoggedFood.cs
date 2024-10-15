using MediatR;
using MongoDB.Bson;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.NutrientTracking.Queries;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class GetLoggedFood
{
	public static void MapGetLoggedFood(this WebApplication app)
	{
		app.MapGet("api/v1/food-log", async (IMediator mediator) =>
		{
			var query = new GetLoggedFoodsQuery(new FoodsQueryFilter()
			{
				FoodIds = [ObjectId.Parse("66f06cbe04260df229ff2702")]
			});
			
			var nutritionState = await mediator.Send(query);
			
			return Results.Ok(nutritionState);
		});
	}
}