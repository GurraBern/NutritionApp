using MediatR;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Tracking.Commands;

public record DeleteLoggedFoodCommand(DateTime Date, Guid LoggedFoodId) : IRequest<Result>;
    
public class DeleteLoggedFood(INutritionDayRepository repository) : IRequestHandler<DeleteLoggedFoodCommand, Result>
{
    public async Task<Result> Handle(DeleteLoggedFoodCommand command, CancellationToken cancellationToken)
    {
        var nutritionDay = await repository.GetByDate(command.Date);
        if (nutritionDay is null)
            return Result.Failure("Nutrition day could not be found");
        
        var result = nutritionDay.DeleteFood(command.LoggedFoodId);
        if (result.IsFailure)
            return result;

        await repository.SaveAsync();

        return result;
    }
}