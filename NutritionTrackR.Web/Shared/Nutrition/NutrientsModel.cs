using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Web.Shared.FoodSearch.AddFood;

namespace NutritionTrackR.Web.Shared.Nutrition;

public class NutrientsModel
{
	public void RecalculateNutrients(List<FoodModel> foods)
	{
		var nutrientDictionary = foods
			.SelectMany(food => food.Nutrients)
			.GroupBy(nutrient => nutrient.Name)
			.ToDictionary(group => group.Key, group =>
				new NutrientWrapper(
					new NutrientDto
					{
						Name = group.Key,
						Weight = group.Sum(nutrient => nutrient.Weight)
					}));

		foreach (var nutrient in AllNutrients)
		{
			nutrient.ClearWeight();
			if (nutrientDictionary.TryGetValue(nutrient.Name, out var combinedNutrient))
			{
				nutrient.AddWeight(combinedNutrient);
			}
		}
	}

	public void SetNutrientTargets(Dictionary<string, NutrientDto> nutrientTargets)
	{
		foreach (var nutrient in AllNutrients)
		{
			if (nutrientTargets.TryGetValue(nutrient.Name, out var nutrientTarget))
			{
				nutrient.SetNutrientTarget(nutrientTarget);
			}
		}
	}
	
	public NutrientWrapper Calories = new(new NutrientDto { Name = "Calories", Unit = nameof(Unit.Kcal), Weight = 0 });
	public NutrientWrapper Protein = new(new NutrientDto { Name = "Protein", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Carbohydrates = new(new NutrientDto { Name = "Carbohydrates", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Fiber = new(new NutrientDto { Name = "Fiber", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Sugars = new(new NutrientDto { Name = "Sugars", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Starch = new(new NutrientDto { Name = "Starch", Unit = nameof(Unit.Grams), Weight = 0 });

	public NutrientWrapper Fat = new(new NutrientDto { Name = "Total Fat", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper SaturatedFat = new(new NutrientDto { Name = "SaturatedFat", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper TransFat = new(new NutrientDto { Name = "TransFat", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper MonounsaturatedFat = new(new NutrientDto { Name = "MonounsaturatedFat", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper PolyunsaturatedFat = new(new NutrientDto { Name = "PolyunsaturatedFat", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Cholesterol = new(new NutrientDto { Name = "Cholesterol", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Omega3 = new(new NutrientDto { Name = "Omega 3", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Omega6 = new(new NutrientDto { Name = "Omega 6", Unit = nameof(Unit.Grams), Weight = 0 });

	// Vitamins
	public NutrientWrapper VitaminA = new(new NutrientDto { Name = "Vitamin A", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper VitaminC = new(new NutrientDto { Name = "Vitamin C", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper VitaminD = new(new NutrientDto { Name = "Vitamin D", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper VitaminB6 = new(new NutrientDto { Name = "Vitamin B6", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper VitaminE = new(new NutrientDto { Name = "Vitamin E", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper VitaminK1 = new(new NutrientDto { Name = "Vitamin K1", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper VitaminK2 = new(new NutrientDto { Name = "Vitamin K2", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Thiamin = new(new NutrientDto { Name = "Thiamin", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Riboflavin = new(new NutrientDto { Name = "Riboflavin", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Niacin = new(new NutrientDto { Name = "Niacin", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper PantothenicAcid = new(new NutrientDto { Name = "Pantothenic Acid", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Biotin = new(new NutrientDto { Name = "Biotin", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper Folate = new(new NutrientDto { Name = "Folate", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper VitaminB12 = new(new NutrientDto { Name = "Vitamin B12", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper TocopherolAlpha = new(new NutrientDto { Name = "Tocopherol Alpha", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Choline = new(new NutrientDto { Name = "Choline", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper FolicAcid = new(new NutrientDto { Name = "Folic Acid", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper CaroteneAlpha = new(new NutrientDto { Name = "Carotene Alpha", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper CaroteneBeta = new(new NutrientDto { Name = "Carotene Beta", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper CryptoxanthinBeta = new(new NutrientDto { Name = "Cryptoxanthin Beta", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper LuteinZeaxanthin = new(new NutrientDto { Name = "Lutein Zeaxanthin", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Lycopene = new(new NutrientDto { Name = "Lycopene", Unit = nameof(Unit.Grams), Weight = 0 });

	// Minerals
	public NutrientWrapper Calcium = new(new NutrientDto { Name = "Calcium", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Chloride = new(new NutrientDto { Name = "Chloride", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Chromium = new(new NutrientDto { Name = "Chromium", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper Iron = new(new NutrientDto { Name = "Iron", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Zinc = new(new NutrientDto { Name = "Zinc", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Sodium = new(new NutrientDto { Name = "Sodium", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Magnesium = new(new NutrientDto { Name = "Magnesium", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Copper = new(new NutrientDto { Name = "Copper", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper Fluoride = new(new NutrientDto { Name = "Fluoride", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Iodine = new(new NutrientDto { Name = "Iodine", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper Molybdenum = new(new NutrientDto { Name = "Molybdenum", Unit = nameof(Unit.Microgram), Weight = 0 });
	public NutrientWrapper Nickel = new(new NutrientDto { Name = "Nickel", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Phosphorus = new(new NutrientDto { Name = "Phosphorus", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Potassium = new(new NutrientDto { Name = "Potassium", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Manganese = new(new NutrientDto { Name = "Manganese", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Selenium = new(new NutrientDto { Name = "Selenium", Unit = nameof(Unit.Microgram), Weight = 0 });

	// Amino Acids
	public NutrientWrapper Alanine = new(new NutrientDto { Name = "Alanine", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Arginine = new(new NutrientDto { Name = "Arginine", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Asparagine = new(new NutrientDto { Name = "Asparagine", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper AsparticAcid = new(new NutrientDto { Name = "Aspartic Acid", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Cystine = new(new NutrientDto { Name = "Cystine", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper GlutamicAcid = new(new NutrientDto { Name = "Glutamic Acid", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Glutamine = new(new NutrientDto { Name = "Glutamine", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Glycine = new(new NutrientDto { Name = "Glycine", Unit = nameof(Unit.Grams), Weight = 0 });
	public NutrientWrapper Histidine = new(new NutrientDto { Name = "Histidine", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Hydroxyproline = new(new NutrientDto { Name = "Hydroxyproline", Unit = nameof(Unit.Grams), Weight = 0 });
    public NutrientWrapper Isoleucine = new(new NutrientDto { Name = "Isoleucine", Unit = nameof(Unit.Milligram), Weight = 0 });
    public NutrientWrapper Leucine = new(new NutrientDto { Name = "Leucine", Unit = nameof(Unit.Milligram), Weight = 0 });
	public NutrientWrapper Lysine = new(new NutrientDto { Name = "Lysine", Unit = nameof(Unit.Milligram), Weight = 0 });
    public NutrientWrapper Methionine = new(new NutrientDto { Name = "Methionine", Unit = nameof(Unit.Milligram), Weight = 0 });
    public NutrientWrapper Phenylalanine = new(new NutrientDto { Name = "Phenylalanine", Unit = nameof(Unit.Milligram), Weight = 0 });
    public NutrientWrapper Proline = new(new NutrientDto { Name = "Proline", Unit = nameof(Unit.Grams), Weight = 0 }); // Nonessential
    public NutrientWrapper Serine = new(new NutrientDto { Name = "Serine", Unit = nameof(Unit.Grams), Weight = 0 }); // Nonessential
    public NutrientWrapper Threonine = new(new NutrientDto { Name = "Threonine", Unit = nameof(Unit.Milligram), Weight = 0 });
    public NutrientWrapper Tryptophan = new(new NutrientDto { Name = "Tryptophan", Unit = nameof(Unit.Milligram), Weight = 0 });
    public NutrientWrapper Tyrosine = new(new NutrientDto { Name = "Tyrosine", Unit = nameof(Unit.Grams), Weight = 0 }); // Nonessential
    public NutrientWrapper Valine = new(new NutrientDto { Name = "Valine", Unit = nameof(Unit.Milligram), Weight = 0 });
	// public static NutrientDto Theobromine => new() { Name = "Theobromine", Unit = UnitDto.Grams, Weight = 0 };

	public List<NutrientWrapper> AllNutrients => [Calories, Protein, Carbohydrates, Fiber, Sugars, Starch, Fat, SaturatedFat, TransFat, MonounsaturatedFat, PolyunsaturatedFat, Chloride, Omega3, Omega6, Cholesterol, VitaminA, VitaminD, VitaminE, VitaminC, VitaminK1, VitaminK2, Thiamin, Riboflavin, Niacin, PantothenicAcid, VitaminB6, Biotin, Folate, VitaminB12, TocopherolAlpha, Choline, FolicAcid, CaroteneAlpha, CaroteneBeta, CryptoxanthinBeta, LuteinZeaxanthin, Lycopene, Calcium, Chromium, Iron, Zinc, Sodium, Magnesium, Copper, Fluoride, Iodine, Molybdenum, Nickel, Phosphorus, Potassium, Manganese, Phosphorus, Selenium, Alanine, Arginine, Asparagine, AsparticAcid, Cystine, GlutamicAcid, Glutamine, Glycine, Histidine, Hydroxyproline, Isoleucine, Leucine, Lysine, Methionine, Phenylalanine, Proline, Serine, Threonine, Tryptophan, Tyrosine, Valine];
}

