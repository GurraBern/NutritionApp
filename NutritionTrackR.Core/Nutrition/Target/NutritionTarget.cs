using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Nutrition.Target;

public class NutritionTarget : AggregateRoot 
{
	public DateTime ActivationDate { get; private set; }
	
	public List<Nutrient> Nutrients { get; private set; } = [];

	private NutritionTarget() {}
	public NutritionTarget(DateTime activationDate, List<Nutrient> nutrients)
	{
		ActivationDate = activationDate;
		Nutrients = nutrients;
	}

	public void AddOrUpdateNutrientTargets(IEnumerable<Nutrient> nutrients)
	{
		foreach (var nutrient in nutrients)
		{
			AddOrUpdateNutrientTarget(nutrient);
		}
	}

	public void AddOrUpdateNutrientTarget(Nutrient nutrient)
	{
		var index = Nutrients.FindIndex(x => x.Name == nutrient.Name);
		if (index != -1)
		{
			UpdateNutrientTarget(nutrient, index);
			return;
		}
		
		Nutrients.Add(nutrient);
	}
	
	private void UpdateNutrientTarget(Nutrient nutrient, int index)
	{
		if (index < 0)
			throw new IndexOutOfRangeException();
		
		Nutrients[index] = nutrient;
	}

	public void AddNutrientTargets(IEnumerable<Nutrient> nutrients)
	{
		var existingNutrientNames = Nutrients.Select(x => x.Name);
		
		//OM den finns ersätt

		var nutrientsToAdd = nutrients.Where(newNutrient => existingNutrientNames.Contains(newNutrient.Name) is false);
		
		Nutrients.AddRange(nutrientsToAdd);
	}
}