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
        
        nutritionDay.UpdateFood(command.LoggedFood);
        await repository.SaveAsync();

        return Result.Success();
    }
}