using MediatR;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Nutrition.Tracking.Commands;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class TrackFood
{
	public static void MapTrackFood(this WebApplication app)
	{
		app.MapPost("api/v1/food-logs", async (IMediator mediator, LogFoodRequest request) =>
		{
			var unitResult = WeightUnit.FromString(request.Unit);
			if(unitResult.IsFailure)
				return Results.BadRequest(unitResult.Error);
			
			var weight = Weight.Create((double)request.Weight, unitResult.Value);
			if (weight.IsFailure)
				return Results.BadRequest(weight.Error);

			var command = new LogFood(new FoodId(request.FoodId), weight.Value, (MealType)request.MealType, request.Date);

			await mediator.Send(command);
			
			return Results.Created();
		});
	}
}