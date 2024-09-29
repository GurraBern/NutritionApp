using MediatR;
using NutritionTrackR.Core.NutrientTracking.Queries;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class GetTrackedFood
{
	public static void MapGetLoggedFood(this WebApplication app)
	{
		app.MapGet("api/v1/food-entry", async (IMediator mediator) =>
		{
			var query = new GetLoggedFoodsQuery();
			
			await mediator.Send(query);
			
			return Results.Ok();
		});
	}
}