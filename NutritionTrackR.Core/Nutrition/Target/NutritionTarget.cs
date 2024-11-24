using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.Nutrition.Target;

public class NutritionTarget
{
	public DateTime ActivationDate { get; set; }
	
	public List<Nutrient> Nutrients { get; set; } = [];
}