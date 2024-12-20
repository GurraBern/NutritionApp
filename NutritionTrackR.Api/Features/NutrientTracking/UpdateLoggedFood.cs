using MediatR;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Nutrition.Tracking;
using NutritionTrackR.Core.Nutrition.Tracking.Commands;
using Unit = NutritionTrackR.Core.Foods.ValueObjects.Unit;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class UpdateLoggedFood
{
	public static void MapUpdateLoggedFood(this WebApplication app)
	{
		app.MapPut("api/v1/food-entry", async (IMediator mediator, UpdateLoggedFoodRequest request) =>
		{
			var foodId = new FoodId(request.FoodId);
			var weight = Weight.Create((double)request.Weight, (Unit)request.Unit);
			if (weight.IsFailure)
				return Results.BadRequest(weight.Error);
			

			var loggedFood = LoggedFood.Create(request.LoggedFoodId, foodId, weight.Value, (MealType)request.MealType);
			
			var command = new UpdateLoggedFoodCommand(loggedFood, request.Date);

			await mediator.Send(command);
			
			return Results.Created();
		});
	}
    
}