using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.Nutrition.Target;

public record NutritionTargetRequest
{
	public DateOnly StartDate { get; set; }
	public List<NutrientDto> NutrientGoals { get; set; } = [];
}