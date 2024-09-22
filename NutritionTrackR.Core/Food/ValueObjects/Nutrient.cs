using FluentResults;

namespace NutritionTrackR.Core.Food.ValueObjects;

public class Nutrient
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
            return Result.Fail("Nutrient must have a name");

        var nutrient = new Nutrient(name, weight);

        return Result.Ok(nutrient);
    }
}
