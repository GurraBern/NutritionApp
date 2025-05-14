using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Core.Nutrition.Tracking.Commands;

namespace NutritionTrackR.Api.Features.NutrientTracking.LoggedFood;

public static class Delete
{
    public static void MapDeleteLoggedFood(this WebApplication app)
    {
        app.MapPost("api/v1/food-logs/delete",
            async ([FromServices] IMediator mediator, [FromBody] DeleteLoggedFoodRequest request) =>
        {
            var command = new DeleteLoggedFoodCommand(request.Date, request.LoggedFoodId);
            
            var result = await mediator.Send(command);

            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound(result.Errors);
        });
    }
}
