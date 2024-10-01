using MediatR;
using NutritionTrackR.Core.NutrientTracking.Queries;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class GetLoggedFood
{
	public static void MapGetLoggedFood(this WebApplication app)
	{
		app.MapGet("api/v1/food-log", async (IMediator mediator) =>
		{
			var query = new GetLoggedFoodsQuery(DateTimeOffset.Now);
			
			await mediator.Send(query);
			
			return Results.Ok();
		});
	}
}