using MediatR;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Tracking.Commands;

public record UpdateLoggedFoodCommand(LoggedFood LoggedFood, DateTime Date) : IRequest<Result>;

public class UpdateLoggedFoodHandler(INutritionDayRepository repository) : IRequestHandler<UpdateLoggedFoodCommand, Result>
{
    public async Task<Result> Handle(UpdateLoggedFoodCommand command, CancellationToken cancellationToken)
    {
        var nutritionDay = await repository.GetByDate(command.Date);
        if (nutritionDay is null)
            return Result.Failure("Nutrition day could not be found");

        var result = nutritionDay.UpdateFood(command.LoggedFood);
        if (result.IsFailure)
            return Result.Failure(result.Error);
        
        await repository.SaveAsync();

        return Result.Success(result);
    }
}