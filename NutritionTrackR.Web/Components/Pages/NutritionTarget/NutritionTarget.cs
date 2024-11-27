using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Web.Components.Pages.NutritionGoal;

namespace NutritionTrackR.Web.Components.Pages.NutritionTarget;

public class NutritionTarget
{
	public List<NutrientDto> NutrientGoals { get; set; } = Nutrients.List();

	public decimal GetProgress(NutrientDto nutrient)
	{
		throw new NotImplementedException();
	}
}