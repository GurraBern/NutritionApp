﻿using MediatR;
using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.NutrientTracking.Queries;

namespace NutritionTrackR.Api.Features.NutrientTracking;

public static class GetLoggedFood
{
    public static void MapGetLoggedFood(this WebApplication app)
    {
        app.MapGet("api/v1/food-log", async (IMediator mediator) =>
        {
            var query = new GetLoggedFoodsQuery(new FoodsQueryFilter
            {
                Date = DateTime.Now
            });

            var result = await mediator.Send(query);
            
            //TODO use dictionary instead
            var response = result.LoggedFoods.Select(loggedFood =>
            {
                var food = result.Foods.First(f => f.Id.ToString() == loggedFood.FoodId.Id);
                return new FoodDto 
                {
                    Name = food.Name,
                    Amount = loggedFood.Weight.Value,
                    Unit = loggedFood.Weight.Unit,
                    Nutrients = food.Nutrients.MapNutrientDtos()
                };
            });

            return Results.Ok(new FoodResponse
            {
                Foods = response.ToList()
            });
        });
    }
}