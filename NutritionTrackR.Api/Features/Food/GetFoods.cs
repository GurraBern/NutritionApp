using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Core.Foods.Queries;

namespace NutritionTrackR.Api.Features.Food;

public static class GetFoods
{
	public static void MapGetFoods(this WebApplication app)
	{
		app.MapGet("api/v1/foods", async ([FromServices] IMediator mediator, [FromQuery] string searchTerm) =>
		{
			var filter = new FoodsQueryFilter()
			{
				Name = searchTerm
			};
			
			var query = new GetFoodsQuery(filter);

			var result = await mediator.Send(query);

			var foods = result.Value.MapFoodResponse();
			
			return Results.Ok(foods);
		});
	}
}