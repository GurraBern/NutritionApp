using MediatR;
using NutritionTrackR.Contracts.NutritionTracking;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.Commands;
using NutritionTrackR.Core.Food.ValueObjects;
using Unit = NutritionTrackR.Core.Food.ValueObjects.Unit;

namespace PersonalHealthAPI.Features.NutrientTracking;

public static class TrackFood
{
	public static void MapTrackFood(this WebApplication app)
	{
		app.MapPost("api/v1/food-entry", async (IMediator mediator, FoodEntryRequest request) =>
		{
			var weight = Weight.Create(request.Weight, (Unit)request.Unit);
			if (weight.IsFailure)
			{
				return Results.BadRequest(weight.Error);
			}

			var command = new AddFoodEntryCommand(request.FoodId, weight.Data, (MealType)request.MealType);

			await mediator.Send(command);
			
			return Results.Created();
		});
	}
}