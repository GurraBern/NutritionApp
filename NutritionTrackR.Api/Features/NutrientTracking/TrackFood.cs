using MediatR;
using NutritionTrackR.Contracts.NutritionTracking;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.NutrientTracking.Commands;
using Unit = NutritionTrackR.Core.Foods.ValueObjects.Unit;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class TrackFood
{
	public static void MapTrackFood(this WebApplication app)
	{
		app.MapPost("api/v1/food-entry", async (IMediator mediator, LogFoodRequest request) =>
		{
			var weight = Weight.Create(request.Weight, (Unit)request.Unit);
			if (weight.IsFailure)
				return Results.BadRequest(weight.Error);

			var command = new LogFoodCommand(new FoodId(request.FoodId), weight.Data, (MealType)request.MealType);

			await mediator.Send(command);
			
			return Results.Created();
		});
	}
}