using MediatR;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.NutrientTracking.Queries;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class GetLoggedFood
{
	public static void MapGetLoggedFood(this WebApplication app)
	{
		app.MapGet("api/v1/food-log", async (IMediator mediator) =>
		{
			var query = new GetLoggedFoodsQuery(new FoodsQueryFilter
			{
				Date = DateTime.Now
			});
			
			var nutritionState = await mediator.Send(query);
			
			//TODO map to response object
			
			return Results.Ok(nutritionState);
		});
	}
}