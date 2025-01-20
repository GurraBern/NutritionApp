using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Target.Queries;

public record GetNutritionTargetQuery(DateTime Date) : IRequest<NutritionTarget>;

public class GetNutritionTarget(INutritionDbContext dbContext) : IRequestHandler<GetNutritionTargetQuery, NutritionTarget>
{
    public async Task<NutritionTarget> Handle(GetNutritionTargetQuery query, CancellationToken cancellationToken = default)
    {
        var nutritionTarget = await dbContext.NutritionTargets
            .OrderByDescending(x => x.ActivationDate)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
        
        return nutritionTarget ?? new NutritionTarget(query.Date, []);
    }
}