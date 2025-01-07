using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Components.Pages.NutritionTarget;

public class DailyNutritionTarget
{
	private Dictionary<string, NutrientDto> NutrientTargets { get; } 

	public DailyNutritionTarget(List<NutrientDto> nutrients)
	{
		NutrientTargets = nutrients.ToDictionary(x => x.Name);
	}

	public double GetProgress(NutrientDto? nutrient)
	{
		if (nutrient is null || !NutrientTargets.TryGetValue(nutrient.Name, out var targetNutrient)) return 0;

		var convertedWeight = ConvertUnit(nutrient);

		return Math.Round(convertedWeight/targetNutrient.Weight, 2) * 100;
	}
	
	public double GetNutrientTarget(NutrientDto nutrient)
	{
		//TODO need to handle better
		if (!NutrientTargets.TryGetValue(nutrient.Name, out var targetNutrient))
			return 0;
		
		return targetNutrient.Weight;
	}
	
	//TODO add pounds and ounces
	private static double ConvertUnit(NutrientDto nutrient) => nutrient.Unit switch
	{
		UnitDto.Grams => nutrient.Weight,
		UnitDto.Milligram => nutrient.Weight * 1_000, 
		UnitDto.Microgram => nutrient.Weight * 1000_000 
	};

	public bool IsComplete(NutrientDto nutrient)
	{
		var progress = GetProgress(nutrient);
		return progress >= 100;
	}
}