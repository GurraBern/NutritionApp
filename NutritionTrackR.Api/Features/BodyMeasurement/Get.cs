using MediatR;
using NutritionTrackR.Contracts.BodyMeasurement;
using NutritionTrackR.Core.BodyMeasurements.Queries;

namespace NutritionTrackR.Api.Features.BodyMeasurement;

public static class Get
{
    public static void MapGetBodyWeightData(this WebApplication app)
    {
        //TODO use version set
        app.MapGet("api/v1/body-measurements", async (IMediator mediator, CancellationToken cancellationToken = default) => {
            var userId = Guid.Parse("29e2d142-21d9-40a5-accf-cd591671f030"); //TODO change to the users id
            
            var query = new GetBodyWeightDataQuery(userId);
            
            var bodyWeightData = await mediator.Send(query, cancellationToken);

            return Results.Ok(new BodyWeightDataResponse()
            {
                BodyWeightData = bodyWeightData.ToList()
            });
        });
    }
}