using FluentResults;
using MediatR;

namespace NutritionTrackR.Core.Nutrition.Tracking.Commands;

public record DeleteLoggedFoodCommand(DateTime Date, Guid LoggedFoodId) : IRequest<Result>;
    
public class DeleteLoggedFood(INutritionDayRepository repository) : IRequestHandler<DeleteLoggedFoodCommand, Result>
{
    public async Task<Result> Handle(DeleteLoggedFoodCommand command, CancellationToken cancellationToken)
    {
        var nutritionDay = await repository.GetByDate(command.Date);
        if (nutritionDay is null)
            return Result.Fail("Nutrition day could not be found");
        
        var result = nutritionDay.DeleteFood(command.LoggedFoodId);
        if (result.IsFailed)
            return result;

        await repository.SaveAsync();

        return result;
    }
}