using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.Nutrition.Target;

public class NutritionTargetRequest
{
	public DateOnly StartDate { get; set; }
	public List<NutrientDto> NutrientGoals { get; set; } = [];
}