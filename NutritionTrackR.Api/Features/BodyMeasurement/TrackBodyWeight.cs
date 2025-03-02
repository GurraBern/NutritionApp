using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Contracts.BodyMeasurement;
using NutritionTrackR.Core.BodyMeasurements.Commands;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Features.BodyMeasurement;

public static class TrackBodyWeight
{
    public static void MapTrackBodyWeight(this WebApplication app)
    {
        app.MapPost("api/v1/body-measurements", async ([FromServices] IMediator mediator, [FromBody] TrackBodyWeightRequest request) => {
            
            request.UserId = Guid.Parse("29e2d142-21d9-40a5-accf-cd591671f030"); //TODO change to the users id
            
            var weightUnitResult = WeightUnit.FromString(request.WeightUnit);
            if (weightUnitResult.IsFailed)
            {
                // TODO add problem details
                return TypedResults.BadRequest();
            }

            var weight = Weight.Create(request.Weight, weightUnitResult.Value);
                
            var command = new TrackBodyWeightCommand(request.UserId, request.Date, weight.Value);
            var result = await mediator.Send(command);
            
            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound(result.Errors);
        });
    }
}