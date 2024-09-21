using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Food;

public class Food : Entity
{
    public string Name { get; }
    public IList<Nutrient> Nutrients { get; }

    public Food(string name, IList<Nutrient> nutrients)
    {
        Name = name;
        Nutrients = nutrients;
    }
}

// TODO Ensure no one can change nutrient through reference