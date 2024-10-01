using MediatR;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.NutrientTracking.Commands;

public record LogFoodCommand(string FoodId, Weight Weight, MealType MealType) : IRequest<Result>;

public class LogFoodCommandHandler(IMediator mediator, INutritionDayRepository repository) : IRequestHandler<LogFoodCommand, Result>
{
	public async Task<Result> Handle(LogFoodCommand command, CancellationToken cancellationToken)
	{
		var nutritionDay = await repository.GetByDate(DateTimeOffset.Now.Date);
		if (nutritionDay is null)
		{
			nutritionDay = new NutritionDay([]);
			await repository.Create(nutritionDay);
		}
		
		nutritionDay.LogFood(command.FoodId, command.Weight, command.MealType);

		await repository.SaveAsync();

		foreach (var loggedFoodEvent in nutritionDay.DomainEvents)
		{
			await mediator.Publish(loggedFoodEvent, cancellationToken);
		}

		nutritionDay.ClearDomainEvents(); //TODO will this be a bug if I don't do save async

		return Result.Success();
	}
}
