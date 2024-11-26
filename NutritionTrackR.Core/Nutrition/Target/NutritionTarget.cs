using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Nutrition.Target;

public class NutritionTarget : Entity
{
	public DateTime ActivationDate { get; set; }
	
	public List<Nutrient> Nutrients { get; set; } = [];
}