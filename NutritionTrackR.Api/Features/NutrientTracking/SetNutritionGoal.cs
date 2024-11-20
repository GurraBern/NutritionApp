using MediatR;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class SetNutritionGoal 
{
    public static void MapSetNutritionGoal(this WebApplication app)
    {
        app.MapPost("api/v1/nutrition-goal/set", async (DateOnly date, IMediator mediator) =>
        {
            

            return;
        });
    }
}
