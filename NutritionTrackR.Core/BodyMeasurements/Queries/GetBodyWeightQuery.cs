using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.WeightTracking;

namespace NutritionTrackR.Core.BodyMeasurements.Queries;

public record BodyWeightQuery(Guid UserId) : IRequest<BodyWeight>;

public class GetBodyWeightQuery(INutritionDbContext dbContext) : IRequestHandler<BodyWeightQuery, BodyWeight>
{
    public async Task<BodyWeight> Handle(BodyWeightQuery request, CancellationToken cancellationToken = default)
    {
        var weightEvents = await dbContext.BodyWeights
            .Where(x => x.UserId == request.UserId)
            .OrderBy(x => x.OccuredAt)
            .ToListAsync(cancellationToken);

        var bodyWeight = new BodyWeight();
        bodyWeight.Process(weightEvents);

        return bodyWeight;
    }
}