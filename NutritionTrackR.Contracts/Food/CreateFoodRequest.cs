using NutritionTrackR.Core.Food.ValueObjects;

namespace NutritionTrackR.Contracts.Food;

public class CreateFoodRequest
{
    public string FoodName { get; set; }
    public IEnumerable<NutrientDto> Nutrients { get; set; } = [];
}

public class NutrientDto
{
    public string Name { get; set; }
    public decimal Weight { get; set; }   
    public Unit Unit { get; set; }
}