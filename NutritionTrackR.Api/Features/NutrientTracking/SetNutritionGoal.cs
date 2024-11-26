using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Contracts.Nutrition.Goals;
using NutritionTrackR.Contracts.Nutrition.Target;
using NutritionTrackR.Core.Nutrition.Target.Commands;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class SetNutritionGoal 
{
    public static void MapSetNutritionTarget(this WebApplication app)
    {
        app.MapPost("api/v1/nutrition-target/set", async (NutritionTargetRequest request, IMediator mediator) => {
            var nutritionGoalsResult = request.NutrientGoals.MapNutrient();
            if (nutritionGoalsResult.IsFailure)
                return Results.BadRequest(nutritionGoalsResult.Error);
            
            var command = new CreateNutritionTargetCommand
            {
                StartDate = request.StartDate.ToDateTime(TimeOnly.MinValue),
                NutrientGoals = nutritionGoalsResult.Value
            };
            
            await mediator.Send(command);

            return Results.Ok();
        });
    }
}
