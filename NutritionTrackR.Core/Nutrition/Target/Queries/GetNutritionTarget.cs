using MediatR;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Target.Queries;

public record GetNutritionTargetQuery(DateTime Date) : IRequest<NutritionTarget>;

public class GetNutritionTarget(INutritionTargetRepository repository) : IRequestHandler<GetNutritionTargetQuery, NutritionTarget>
{
    public async Task<NutritionTarget> Handle(GetNutritionTargetQuery query, CancellationToken cancellationToken)
    {
        var nutritionTarget = await repository.GetNutritionTarget();
        return nutritionTarget ?? new NutritionTarget(query.Date, []);
    }
}