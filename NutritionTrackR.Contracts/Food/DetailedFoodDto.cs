namespace NutritionTrackR.Contracts.Food;

public class DetailedFoodDto
{
    public string Name { get; set; }
    public List<NutrientDto> Nutrients { get; set; }
}
