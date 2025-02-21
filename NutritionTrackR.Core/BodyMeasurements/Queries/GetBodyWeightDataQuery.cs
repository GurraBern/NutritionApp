using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Contracts.BodyMeasurement;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.BodyMeasurements.Queries;

public record GetBodyWeightDataQuery(Guid UserId) : IRequest<IEnumerable<WeightDto>>;

public class GetCurrentBodyWeightDataQueryHandler(INutritionDbContext dbContext) : IRequestHandler<GetBodyWeightDataQuery, IEnumerable<WeightDto>>
{
    public async Task<IEnumerable<WeightDto>> Handle(GetBodyWeightDataQuery query, CancellationToken cancellationToken = default)
    {
        var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
        
        var bodyWeights = await dbContext.BodyWeights
            .AsNoTracking()
            .Where(x => x.OccuredAt >= startOfYear)
            .ToListAsync(cancellationToken);

        var bodyWeightData = bodyWeights.ToDto();

        return bodyWeightData;
    }
}