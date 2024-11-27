using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Nutrition.Target;

public class NutritionTarget : AggregateRoot 
{
	public DateTime ActivationDate { get; set; }
	
	public List<Nutrient> Nutrients { get; private set; } = [];

	private NutritionTarget() {}
	public NutritionTarget(DateTime activationDate, List<Nutrient> nutrients)
	{
		ActivationDate = activationDate;
		Nutrients = nutrients;
	}

	public void ReplaceNutrients(List<Nutrient> nutrients)
	{
		Nutrients = nutrients;
	}
}