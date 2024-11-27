using MediatR;
using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Contracts.Nutrition.Target;
using NutritionTrackR.Core.Nutrition.Target.Commands;
using NutritionTrackR.Core.Nutrition.Target.Queries;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class GetNutritionTarget
{
    public static void MapGetNutritionTarget(this WebApplication app)
    {
        app.MapGet("api/v1/nutrition-target", async (IMediator mediator) => {
            
            var query = new GetNutritionTargetQuery(DateTime.Now);
            
            var result = await mediator.Send(query);
            if (result.IsFailure)
                return Results.NotFound(result.Error);

            var nutritionTarget = result.Value;
            return Results.Ok(new NutritionTargetDto
            {
                Nutrients = nutritionTarget.Nutrients.MapNutrientDtos()
            });
        });
    }
}