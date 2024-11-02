using MediatR;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.NutrientTracking.Commands;

public record LogFoodCommand(FoodId FoodId, Weight Weight, MealType MealType) : IRequest<Result>;

public class LogFoodCommandHandler(INutritionDayRepository repository) : IRequestHandler<LogFoodCommand, Result>
{
	public async Task<Result> Handle(LogFoodCommand command, CancellationToken cancellationToken)
	{
		var nutritionDay = await repository.GetByDate(DateTime.Now.Date);
		if (nutritionDay is null)
		{
			nutritionDay = new NutritionDay();
			await repository.Create(nutritionDay);
		}
		
		nutritionDay.LogFood(command.FoodId, command.Weight, command.MealType);

		await repository.SaveAsync();

		return Result.Success();
	}
}
