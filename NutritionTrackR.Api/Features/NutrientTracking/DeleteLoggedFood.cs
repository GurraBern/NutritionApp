using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Contracts;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Core.Nutrition.Tracking.Commands;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class DeleteLoggedFood
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
                : Results.NotFound(ApiResponse.Failure(result.Error));
        });
    }
}
