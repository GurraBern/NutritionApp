using FluentResults;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.Foods.ValueObjects;

public record Nutrient
{
    public string Name { get; private set; }
    public Weight Weight { get; private set; }
    
    private Nutrient() { }
    
    private Nutrient(string name, Weight weight)
    {
        Name = name;
        Weight = weight;
    }

    public static Result<Nutrient> Create(string name, Weight weight)
    {
        if (string.IsNullOrEmpty(name))
            return Result.Fail(FoodErrors.EmptyNutrientName);

        var nutrient = new Nutrient(name, weight);
        
        return Result.Ok(nutrient);
    }
}
