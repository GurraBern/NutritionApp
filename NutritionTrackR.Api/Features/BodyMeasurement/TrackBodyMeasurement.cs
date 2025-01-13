using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Contracts;
using NutritionTrackR.Contracts.BodyMeasurement;
using NutritionTrackR.Core.BodyMeasurements;
using NutritionTrackR.Core.BodyMeasurements.ValueObjects;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Features.BodyMeasurement;

public static class TrackBodyMeasurement
{
    public static void MapTrackBodyMeasurement(this WebApplication app)
    {
        app.MapPost("api/v1/body-measurements", async ([FromServices] IMediator mediator, [FromBody] TrackBodyMeasurementRequest request) => {

            var measurements = from measurementDto in request.Measurements
                let unit = MeasurementUnit.FromString(measurementDto.Unit)
                select Measurement.Create(measurementDto.Length, unit)
                into measurement
                where measurement.IsSuccess
                select measurement.Value;

            var weightUnitResult = WeightUnit.FromString(request.WeightUnit);
            if (weightUnitResult.IsFailure)
            {
                // TODO add problem details
                return TypedResults.BadRequest();
            }

            var weight = Weight.Create(request.Weight, weightUnitResult.Value);
                
            var command = new TrackBodyMeasurementCommand(request.Date, weight.Value, measurements);
            var result = await mediator.Send(command);
            
            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound(ApiResponse.Failure(result.Error));
        });
    }
}