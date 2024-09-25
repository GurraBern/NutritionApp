using NutritionTrackR.Core.Food.Queries;

namespace PersonalHealthAPI.Features.Food;

using FluentResults;
using MediatR;

public static class GetFoods 
{
	//TODO better return type
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
			
			return Result.Ok(result.Value); 
		});
	}
}