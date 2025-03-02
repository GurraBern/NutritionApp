using FluentResults;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Api.Extensions;

public static class NutrientMapper
{
    public static Result<List<Nutrient>> MapNutrient(this List<NutrientDto> nutrientDtos)
    {
        var nutrients = new List<Nutrient>();
        foreach (var nutrientDto in nutrientDtos)
        {
            var unitResult = WeightUnit.FromString(nutrientDto.Unit);
            var weightResult = Weight.Create(nutrientDto.Weight, unitResult.Value);
            var nutrientResult = Nutrient.Create(nutrientDto.Name, weightResult.Value);

            Result.Merge(unitResult, weightResult, nutrientResult);

            nutrients.Add(nutrientResult.Value);
        }

        return Result.Ok(nutrients);
    }
}