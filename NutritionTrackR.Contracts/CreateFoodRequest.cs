using NutritionTrackR.Core.Food.ValueObjects;

namespace NutritionTrackR.Contracts;

public class CreateFoodRequest
{
    public string FoodName { get; set; }
    public IEnumerable<NutrientDto> Nutrients { get; set; } = [];
    public MeasurementSystem MeasurementSystem { get; set; }
}

public class NutrientDto
{
    public string Name { get; set; }
    public decimal Weight { get; set; }   
}