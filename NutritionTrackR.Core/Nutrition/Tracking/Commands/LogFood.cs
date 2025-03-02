using FluentResults;
using MediatR;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.Nutrition.Tracking.Commands;

public record LogFood(FoodId FoodId, Weight Weight, MealType MealType, DateTime Date) : IRequest<Result>;

public class LogFoodCommandHandler(INutritionDayRepository repository) : IRequestHandler<LogFood, Result>
{
	public async Task<Result> Handle(LogFood command, CancellationToken cancellationToken)
	{
		var nutritionDay = await repository.GetByDate(command.Date);
		if (nutritionDay is null)
		{
			nutritionDay = new NutritionDay();
			await repository.Create(nutritionDay);
		}
		
		nutritionDay.LogFood(command.FoodId, command.Weight, command.MealType);

		await repository.SaveAsync();

		return Result.Ok();
	}
}
