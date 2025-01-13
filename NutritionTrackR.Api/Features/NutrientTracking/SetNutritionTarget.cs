using MediatR;
using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Contracts.Nutrition.Target;
using NutritionTrackR.Core.Nutrition.Target.Commands;
using NutritionTrackR.Web.Extensions;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class SetNutritionTarget 
{
    public static void MapSetNutritionTarget(this WebApplication app)
    {
        app.MapPost("api/v1/nutrition-targets/set", async (NutritionTargetRequest request, IMediator mediator) => {
            var nutritionGoalsResult = request.NutrientGoals.MapNutrient();
            if (nutritionGoalsResult.IsFailure)
                return Results.BadRequest(nutritionGoalsResult.Error);

            var command = new CreateNutritionTargetCommand(request.StartDate.ToDateTime(), nutritionGoalsResult.Value);
            
            await mediator.Send(command);

            return Results.Ok();
        });
    }
}
