using MediatR;
using NutritionTrackR.Contracts;
using NutritionTrackR.Contracts.NutritionTracking;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.Commands;
using NutritionTrackR.Core.Food.ValueObjects;

namespace PersonalHealthAPI.Features.NutrientTracking;

public static class TrackFood
{
	public static void MapTrackFood(this WebApplication app)
	{
		app.MapPost("api/v1/food-entry", async (IMediator mediator, FoodEntryRequest request) =>
		{
			var weight = Weight.Create(request.Weight, request.Unit);
			if (weight.IsFailed)
			{
				//TODO return error message
				return;
			}

			var command = new AddFoodEntryCommand(request.FoodId, weight.Value, request.MealType ?? MealType.Unclassified);

			await mediator.Send(command);
		});
	}
}