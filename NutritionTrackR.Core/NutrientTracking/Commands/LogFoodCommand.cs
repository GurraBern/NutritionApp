using MediatR;
using MongoDB.Bson.Serialization.Serializers;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.NutrientTracking.Commands;

public record LogFoodCommand(string FoodId, Weight Weight, MealType MealType) : IRequest<Result>;

public class LogFoodCommandHandler(IMediator mediator, INutritionDayRepository repository) : IRequestHandler<LogFoodCommand, Result>
{
	public async Task<Result> Handle(LogFoodCommand command, CancellationToken cancellationToken)
	{
		var t = await repository.GetById("67081d917268cbe0081c2a31");

		var b = t.Date == DateTime.Now.Date;
		var nutritionDay = await repository.GetByDate(DateTime.Now.Date);
		if (nutritionDay is null)
		{
			nutritionDay = new NutritionDay();
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
