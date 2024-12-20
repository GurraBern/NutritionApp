using MediatR;
using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.Nutrition.Tracking.Queries;
using GetLoggedFoodResponse = NutritionTrackR.Contracts.Nutrition.NutritionTracking.LoggedFoodResponse;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class GetLoggedFood
{
    public static void MapGetLoggedFood(this WebApplication app)
    {
        app.MapGet("api/v1/food-log", async (DateOnly date, IMediator mediator) =>
        {
            var query = new GetLoggedFoodsQuery(new FoodsQueryFilter
            {
                Date = date.ToDateTime(TimeOnly.MaxValue)
            });

            var result = await mediator.Send(query);
            
            //TODO use dictionary instead
            var loggedFoodDtos = result.LoggedFoods.Select(loggedFood =>
            {
                var food = result.Foods.First(f => f.Id.ToString() == loggedFood.FoodId.Id);
                return new LoggedFoodDto 
                {
                    Id = loggedFood.FoodId.Id,
                    LoggedFoodId = loggedFood.LoggedFoodId,
                    Name = food.Name,
                    Amount = loggedFood.Weight.Value,
                    Unit = (UnitDto)loggedFood.Weight.Unit,
                    Nutrients = food.Nutrients.MapNutrientDtos(),
                    MealType = (MealTypeDto)loggedFood.MealType
                };
            });

            return Results.Ok(new GetLoggedFoodResponse
            {
                Foods = loggedFoodDtos.ToList()
            });
        });
    }
}
