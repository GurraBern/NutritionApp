using MediatR;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Target.Queries;

public record GetNutritionTargetQuery(DateTime Date) : IRequest<Result<NutritionTarget>>;

public class GetNutritionTarget(INutritionTargetRepository repository) : IRequestHandler<GetNutritionTargetQuery, Result<NutritionTarget>>
{
    public async Task<Result<NutritionTarget>> Handle(GetNutritionTargetQuery query, CancellationToken cancellationToken)
    {
        var nutritionTarget = await repository.GetNutritionTarget(query.Date);
        return nutritionTarget is null
            ? Result.Failure<NutritionTarget>(NutritionTargetErrors.NoExistingNutritionTargets)
            : Result.Success(nutritionTarget);
    }
}