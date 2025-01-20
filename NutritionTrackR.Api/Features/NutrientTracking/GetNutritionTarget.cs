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
        app.MapGet("api/v1/nutrition-targets", async (IMediator mediator, CancellationToken cancellationToken) => {
            
            var query = new GetNutritionTargetQuery(DateTime.Now);
            
            var nutritionTarget = await mediator.Send(query, cancellationToken);

            return Results.Ok(new NutritionTargetDto
            {
                Nutrients = nutritionTarget.Nutrients.MapNutrientDtos()
            });
        });
    }
}