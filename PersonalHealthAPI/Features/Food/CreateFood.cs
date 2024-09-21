using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackR.Contracts;
using NutritionTrackR.Core.Food.Commands;
using NutritionTrackR.Core.Food.ValueObjects;

namespace PersonalHealthAPI.Features.Food;

public static class CreateFood
{
       public static void MapCreateFood(this WebApplication app)
       {
              app.MapPost("api/v1/food", async ([FromBody] CreateFoodRequest request, IMediator mediator) =>
              {
                     var nutrients = ConvertToDomainNutrients(request);

                     var command = new CreateFoodCommand(request.FoodName, nutrients);

                     await mediator.Send(command);
                     
                     return Result.Ok(); 
              });
       }

       private static List<Nutrient> ConvertToDomainNutrients(CreateFoodRequest request)
       {
              List<Nutrient> nutrients = [];
              foreach (var nutrient in request.Nutrients)
              {
                     var weight = Weight.Create(nutrient.Weight, request.MeasurementSystem).Value;
                     nutrients.Add(Nutrient.Create(nutrient.Name, weight).Value);
              }

              return nutrients;
       }
}