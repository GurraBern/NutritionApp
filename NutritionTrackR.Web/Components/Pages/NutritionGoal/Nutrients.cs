using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Components.Pages.NutritionGoal;

public class Nutrients
{
	public static NutrientDto Protein => new() { Name = "Protein", Unit = UnitDto.Grams, Weight = 100 };
	public static NutrientDto Carbs => new() { Name = "Carbohydrates", Unit = UnitDto.Grams, Weight = 225 };
	public static NutrientDto Fat => new() { Name = "Fat", Unit = UnitDto.Grams, Weight = 60 };


	public static List<NutrientDto> List()
	{
		return [Protein, Carbs, Fat];
	}
}