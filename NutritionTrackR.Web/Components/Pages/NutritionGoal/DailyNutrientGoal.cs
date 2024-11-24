using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Components.Pages.NutritionGoal;

public class DailyNutrientGoal
{
	public List<NutrientDto> NutrientGoals { get; set; } = Nutrients.List();

	public decimal GetProgress(NutrientDto nutrient)
	{
		throw new NotImplementedException();
	}
}