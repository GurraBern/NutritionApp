using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Extensions;

public static class NutrientMapper
{
    public static Result<List<Nutrient>> MapNutrient(this List<NutrientDto> nutrientDtos)
    {
        var nutrients = new List<Nutrient>();
        foreach (var nutrientDto in nutrientDtos)
        {
            var unit = WeightUnit.FromString(nutrientDto.Unit);
            if (unit.IsFailure)
                return Result.Failure<List<Nutrient>>(unit.Error);
                
            var weight = Weight.Create(nutrientDto.Weight, unit.Value);
            if (weight.IsFailure)
                return Result.Failure<List<Nutrient>>(weight.Error);
            
            var nutrient = Nutrient.Create(nutrientDto.Name, weight.Value);
            if (nutrient.IsFailure)
                return Result.Failure<List<Nutrient>>(nutrient.Error);

            nutrients.Add(nutrient.Value);
        }

        return Result.Success(nutrients);
    }
}