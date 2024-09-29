using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Food;

public class Food : Entity
{
    public string Name { get; private set;  }
    public List<Nutrient> Nutrients { get; private set; } = [];

    private Food() { }
    
    private Food(string name, List<Nutrient> nutrients)
    {
        Name = name;
        Nutrients = nutrients;
    }

    public static Result<Food> Create(string name, List<Nutrient> nutrients)
    {
        var food = new Food(name, nutrients);

        return Result.Success(food);
    }
}
