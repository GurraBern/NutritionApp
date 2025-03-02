using FluentResults;
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
			var weightResult = Weight.Create((double)request.Weight, unitResult.Value);
			var mergedResult = Result.Merge(unitResult, weightResult);

			if (mergedResult.IsFailed)
				return Results.BadRequest(mergedResult.Errors);
			
			var command = new LogFood(new FoodId(request.FoodId), weightResult.Value, (MealType)request.MealType, request.Date);

			await mediator.Send(command);
			
			return Results.Created();
		});
	}
}