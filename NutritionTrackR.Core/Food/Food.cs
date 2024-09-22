using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Food;

public class Food : Entity
{
    public string Name { get; set;  }
    public List<Nutrient> Nutrients { get; set; } = [];

    public Food() { }
    
    public Food(string name, List<Nutrient> nutrients)
    {
        Name = name;
        Nutrients = nutrients;
    }
}
