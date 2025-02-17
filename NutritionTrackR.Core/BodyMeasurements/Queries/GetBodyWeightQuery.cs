using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.BodyMeasurements.Events;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.BodyMeasurements.Queries;

public record BodyWeightQuery(Guid UserId) : IRequest<BodyWeight>;

public class GetBodyWeightQuery(INutritionDbContext dbContext) : IRequestHandler<BodyWeightQuery, BodyWeight>, IRequest<IList<BodyWeight>>, IRequest<List<BodyWeight>>, IRequest<List<WeightEvent>>
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