using FluentResults;
using MediatR;

namespace NutritionTrackR.Core.Nutrition.Tracking.Commands;

public record UpdateLoggedFoodCommand(LoggedFood LoggedFood, DateTime Date) : IRequest<Result>;

public class UpdateLoggedFoodHandler(INutritionDayRepository repository) : IRequestHandler<UpdateLoggedFoodCommand, Result>
{
    public async Task<Result> Handle(UpdateLoggedFoodCommand command, CancellationToken cancellationToken)
    {
        var nutritionDay = await repository.GetByDate(command.Date);
        if (nutritionDay is null)
            return Result.Fail("Nutrition day could not be found");

        var result = nutritionDay.UpdateFood(command.LoggedFood);
        if (result.IsFailed)
            return Result.Fail(result.Errors);
        
        await repository.SaveAsync();

        return Result.Ok();
    }
}