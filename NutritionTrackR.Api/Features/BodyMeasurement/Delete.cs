using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using NutritionTrackR.Contracts.BodyMeasurement;
using NutritionTrackR.Core.BodyMeasurements.Commands;
using NutritionTrackR.Core.BodyMeasurements.Queries;

namespace NutritionTrackR.Api.Features.BodyMeasurement;

public static class Delete
{
    public static void MapDeleteWeight(this WebApplication app)
    {
        app.MapDelete("api/v1/body-measurements/{id}", async ([FromServices] IMediator mediator, [FromRoute] string id, CancellationToken cancellationToken = default) => 
        {
            var userId = Guid.Parse("29e2d142-21d9-40a5-accf-cd591671f030"); //TODO change to the users id

            var command = new DeleteWeightCommand(ObjectId.Parse(id));
            
            await mediator.Send(command, cancellationToken);
            
            return Results.Ok();
        });
    }
}