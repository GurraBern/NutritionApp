using MediatR;
using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.NutrientTracking;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Food.Commands;

public record AddFoodEntryCommand(string FoodId, Weight Weight, MealType MealType) : IRequest<Result>;

public class AddFoodEntryCommandHandler(IMediator mediator, INutritionDayRepository repository) : IRequestHandler<AddFoodEntryCommand, Result>
{
	public async Task<Result> Handle(AddFoodEntryCommand command, CancellationToken cancellationToken)
	{
		var nutritionDay = await repository.GetById(command.FoodId);
		if (nutritionDay is null)
		{
			nutritionDay = new NutritionDay();
			await repository.Create(nutritionDay);
		}
		
		nutritionDay.LogFood(command.FoodId, command.Weight, command.MealType);

		await repository.SaveAsync();

		foreach (var loggedFoodEvent in nutritionDay.LoggedFoodEvents)
		{
			await mediator.Publish(loggedFoodEvent, cancellationToken);
		}

		nutritionDay.ClearDomainEvents(); //TODO will this be a bug if I don't do save async

		return Result.Success();
	}
}
