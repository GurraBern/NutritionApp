using MediatR;
using NutritionTrackR.Core.BodyMeasurements.Events;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.BodyMeasurements.Commands;

public record TrackBodyWeightCommand(Guid UserId, DateTime Date, Weight Weight) : IRequest<Result>;

public class TrackBodyWeightRequestHandler(INutritionDbContext dbContext) : IRequestHandler<TrackBodyWeightCommand, Result>
{
    public async Task<Result> Handle(TrackBodyWeightCommand command, CancellationToken cancellationToken = default)
    {
        var weightTracked = new WeightTracked(command.UserId, command.Weight)
        {
            OccuredAt = command.Date
        };

        dbContext.BodyWeights.Add(weightTracked);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    
    // TODO Bodymeasurements (index på user och datum?)
}