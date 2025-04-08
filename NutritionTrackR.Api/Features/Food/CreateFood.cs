using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Core.Foods.Commands;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Features.Food;

public static class CreateFood
{
    public static void MapCreateFood(this WebApplication app)
    {
        app.MapPost("api/v1/foods", async ([FromBody] CreateFoodRequest request, IMediator mediator) =>
        {
            //TODO validate that no nutrient appears twice!
            //TODO if no nutrition bad request
            
            var nutrients = ConvertToDomainNutrients(request);

            var command = new CreateFoodCommand(request.Name, nutrients);

            await mediator.Send(command);

            return Results.Created();
        });
    }

    //TODO for consumers of api there should be details about why the food could not be created, we dont want half created foods with missing ingredients!!!
    private static List<Nutrient> ConvertToDomainNutrients(CreateFoodRequest request)
    {
        List<Nutrient> nutrients = [];
        foreach (var nutrient in request.Nutrients)
        {
            var unitResult = WeightUnit.FromString(nutrient.Unit);
            var weightResult = Weight.Create(nutrient.Weight, unitResult.Value);

            var result = Result.Merge(unitResult, weightResult);
            if (result.IsSuccess)
                nutrients.Add(Nutrient.Create(nutrient.Name, weightResult.Value).Value);
        }

        return nutrients;
    }
}