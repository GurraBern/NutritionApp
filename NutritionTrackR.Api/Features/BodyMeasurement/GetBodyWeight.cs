using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Core.BodyMeasurements.Queries;

namespace NutritionTrackR.Api.Features.BodyMeasurement;

public static class GetBodyWeight
{
    public static void MapGetBodyWeight(this WebApplication app)
    {
        app.MapGet("api/v1/body-measurements/{id:int}/current-weight", async ([FromServices] IMediator mediator, [FromRoute] int id, CancellationToken cancellationToken = default) => {
            var userId = Guid.Parse("29e2d142-21d9-40a5-accf-cd591671f030"); //TODO change to the users id
            
            var query = new BodyWeightQuery(userId);
            
            var result = await mediator.Send(query, cancellationToken);
            
            //TODO return response
            return Results.Ok();
        });
    }
}