﻿using MediatR;
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
            var nutrients = ConvertToDomainNutrients(request);

            var command = new CreateFoodCommand(request.Name, nutrients);

            await mediator.Send(command);

            return Results.Created();
        });
    }

    private static List<Nutrient> ConvertToDomainNutrients(CreateFoodRequest request)
    {
        List<Nutrient> nutrients = [];
        foreach (var nutrient in request.Nutrients)
        {
            var unit = WeightUnit.FromString(nutrient.Unit);
            if (unit.IsFailure)
            {
                //TODO find way to return fail to create certain nutrient
                continue;
            }
                
            var weight = Weight.Create(nutrient.Weight, unit.Value);
            if (weight.IsSuccess)
                nutrients.Add(Nutrient.Create(nutrient.Name, weight.Value).Value);
        }

        return nutrients;
    }
}