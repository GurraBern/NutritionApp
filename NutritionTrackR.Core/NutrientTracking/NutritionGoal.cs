using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.NutrientTracking;

public class NutritionGoal
{
	public DateTime ActivationDate { get; set; }
	
	public List<Nutrient> Nutrients { get; set; } = [];
}