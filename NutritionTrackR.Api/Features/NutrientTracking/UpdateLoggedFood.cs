using MediatR;
using NutritionTrackR.Contracts;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Nutrition.Tracking;
using NutritionTrackR.Core.Nutrition.Tracking.Commands;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class UpdateLoggedFood
{
	public static void MapUpdateLoggedFood(this WebApplication app)
	{
		app.MapPut("api/v1/food-logs", async (IMediator mediator, UpdateLoggedFoodRequest request) =>
		{
			var unitResult = WeightUnit.FromString(request.Unit);
			if(unitResult.IsFailure)
				return Results.BadRequest(unitResult.Error);
			
			var weight = Weight.Create((double)request.Weight, unitResult.Value);
			if (weight.IsFailure)
				return Results.BadRequest(weight.Error);
			
			var loggedFood = LoggedFood.Create(request.LoggedFoodId, new FoodId(request.FoodId), weight.Value, (MealType)request.MealType);
			
			var command = new UpdateLoggedFoodCommand(loggedFood, request.Date);

			var result = await mediator.Send(command);
			return result.IsFailure
				? Results.NotFound(ApiResponse.Failure(result.Error))
				: Results.Created("", ApiResponse.Success());
		});
	}
}