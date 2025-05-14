using FluentResults;
using MediatR;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Nutrition.Tracking.Commands;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Features.NutrientTracking.LoggedFood;

public static class Update
{
	public static void MapUpdateLoggedFood(this WebApplication app)
	{
		app.MapPut("api/v1/food-logs", async (IMediator mediator, UpdateLoggedFoodRequest request) =>
		{
			var unitResult = WeightUnit.FromString(request.Unit);
			var weightResult = Weight.Create((double)request.Weight, unitResult.Value);
			
			var mergedResult = Result.Merge(unitResult, weightResult);
			if(mergedResult.IsFailed)
				return Results.BadRequest(mergedResult.Errors);
			
			var loggedFood = Core.Nutrition.Tracking.LoggedFood.Create(request.LoggedFoodId, new FoodId(request.FoodId), weightResult.Value, (MealType)request.MealType);
			
			var command = new UpdateLoggedFoodCommand(loggedFood, request.Date);

			var result = await mediator.Send(command);
			return result.IsSuccess
				? Results.Created()
				: Results.NotFound(result.Errors);
		});
	}
}