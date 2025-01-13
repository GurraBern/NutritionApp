using MediatR;
using NutritionTrackR.Core.BodyMeasurements.ValueObjects;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.BodyMeasurements;

public record TrackBodyMeasurementCommand(DateTime Date, Weight Weight, IEnumerable<Measurement> Measurements) : IRequest<Result>;

public class TrackBodyMeasurementRequestHandler(INutritionDbContext dbContext) : IRequestHandler<TrackBodyMeasurementCommand, Result>
{
    public async Task<Result> Handle(TrackBodyMeasurementCommand request, CancellationToken cancellationToken)
    {
        var bodyMeasurement = new BodyMeasurement(request.Date, request.Weight, request.Measurements);

        dbContext.BodyMeasurements.Add(bodyMeasurement);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    
    // TODO Bodymeasurements (index på user och datum?)
}