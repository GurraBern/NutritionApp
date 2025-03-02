using FluentResults;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Foods;

public class Food : Entity
{
    public string Name { get; set;  }
    public string? ExternalId { get; set; }
    public List<Nutrient> Nutrients { get; set; } = [];

    private Food() { }
    
    private Food(string name, List<Nutrient> nutrients)
    {
        Name = name;
        Nutrients = nutrients;
    }

    public static Result<Food> Create(string name, List<Nutrient> nutrients)
    {
        var food = new Food(name, nutrients);

        return Result.Ok(food);
    }
}
