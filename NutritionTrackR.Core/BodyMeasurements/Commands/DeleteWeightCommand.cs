using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.BodyMeasurements.Commands;

public record DeleteWeightCommand(ObjectId Id) : IRequest;

public record DeleteWeightCommandHandler(INutritionDbContext DbContext) : IRequestHandler<DeleteWeightCommand>
{
    public async Task Handle(DeleteWeightCommand command, CancellationToken cancellationToken = default)
    {
        var weightEntry = DbContext.BodyWeights.First(x => x.Id == command.Id);

        DbContext.BodyWeights.Remove(weightEntry);

        await DbContext.SaveChangesAsync(cancellationToken);

    }
}