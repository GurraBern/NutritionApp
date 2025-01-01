namespace NutritionTrackR.Contracts.Food;

public record DetailedFoodDto
{
    public string Name { get; set; }
    public List<NutrientDto> Nutrients { get; set; }
}
