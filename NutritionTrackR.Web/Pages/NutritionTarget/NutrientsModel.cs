using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Web.Shared;
using NutritionTrackR.Web.Shared.FoodSearch.AddFood;

namespace NutritionTrackR.Web.Pages.NutritionTarget;

public class NutrientsModel
{
	public void RecalculateNutrients(List<FoodModel> foods)
	{
		var nutrientDictionary = foods
			.SelectMany(food => food.Nutrients)
			.GroupBy(nutrient => nutrient.Name)
			.ToDictionary(group => group.Key, group => new NutrientWrapper(new NutrientDto
			{
				Name = group.Key,
				Weight = group.Sum(nutrient => nutrient.Weight)
			}));

		foreach (var nutrient in NutrientList)
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
		foreach (var nutrient in NutrientList)
		{
			if (nutrientTargets.TryGetValue(nutrient.Name, out var nutrientTarget))
			{
				nutrient.SetNutrientTarget(nutrientTarget);
			}
		}
	}
	
	public NutrientWrapper Calories = new(new NutrientDto { Name = "Calories", Unit = UnitDto.Kcal, Weight = 0 });
	public NutrientWrapper Protein = new(new NutrientDto { Name = "Protein", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Carbohydrates = new(new NutrientDto { Name = "Carbohydrates", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Fiber = new(new NutrientDto { Name = "Fiber", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Sugars = new(new NutrientDto { Name = "Sugars", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Starch = new(new NutrientDto { Name = "Starch", Unit = UnitDto.Grams, Weight = 0 });

	public NutrientWrapper Fat = new(new NutrientDto { Name = "Fat", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper SaturatedFat = new(new NutrientDto { Name = "SaturatedFat", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper TransFat = new(new NutrientDto { Name = "TransFat", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper MonounsaturatedFat = new(new NutrientDto { Name = "MonounsaturatedFat", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper PolyunsaturatedFat = new(new NutrientDto { Name = "PolyunsaturatedFat", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Cholesterol = new(new NutrientDto { Name = "Cholesterol", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Omega3 = new(new NutrientDto { Name = "Omega 3", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Omega6 = new(new NutrientDto { Name = "Omega 6", Unit = UnitDto.Grams, Weight = 0 });

	// Vitamins
	public NutrientWrapper VitaminA = new(new NutrientDto { Name = "Vitamin A", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper VitaminC = new(new NutrientDto { Name = "Vitamin C", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper VitaminD = new(new NutrientDto { Name = "Vitamin D", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper VitaminB6 = new(new NutrientDto { Name = "Vitamin B6", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper VitaminE = new(new NutrientDto { Name = "Vitamin E", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper VitaminK1 = new(new NutrientDto { Name = "Vitamin K1", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper VitaminK2 = new(new NutrientDto { Name = "Vitamin K2", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Thiamin = new(new NutrientDto { Name = "Thiamin", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Riboflavin = new(new NutrientDto { Name = "Riboflavin", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Niacin = new(new NutrientDto { Name = "Niacin", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper PantothenicAcid = new(new NutrientDto { Name = "Pantothenic Acid", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Biotin = new(new NutrientDto { Name = "Biotin", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper Folate = new(new NutrientDto { Name = "Folate", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper VitaminB12 = new(new NutrientDto { Name = "Vitamin B12", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper TocopherolAlpha = new(new NutrientDto { Name = "Tocopherol Alpha", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Choline = new(new NutrientDto { Name = "Choline", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper FolicAcid = new(new NutrientDto { Name = "Folic Acid", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper CaroteneAlpha = new(new NutrientDto { Name = "Carotene Alpha", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper CaroteneBeta = new(new NutrientDto { Name = "Carotene Beta", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper CryptoxanthinBeta = new(new NutrientDto { Name = "Cryptoxanthin Beta", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper LuteinZeaxanthin = new(new NutrientDto { Name = "Lutein Zeaxanthin", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Lycopene = new(new NutrientDto { Name = "Lycopene", Unit = UnitDto.Grams, Weight = 0 });

	// Minerals
	public NutrientWrapper Calcium = new(new NutrientDto { Name = "Calcium", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Chloride = new(new NutrientDto { Name = "Chloride", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Chromium = new(new NutrientDto { Name = "Chromium", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper Iron = new(new NutrientDto { Name = "Iron", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Zinc = new(new NutrientDto { Name = "Zinc", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Sodium = new(new NutrientDto { Name = "Sodium", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Magnesium = new(new NutrientDto { Name = "Magnesium", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Copper = new(new NutrientDto { Name = "Copper", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper Fluoride = new(new NutrientDto { Name = "Fluoride", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Iodine = new(new NutrientDto { Name = "Iodine", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper Molybdenum = new(new NutrientDto { Name = "Molybdenum", Unit = UnitDto.Microgram, Weight = 0 });
	public NutrientWrapper Nickel = new(new NutrientDto { Name = "Nickel", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Phosphorus = new(new NutrientDto { Name = "Phosphorus", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Potassium = new(new NutrientDto { Name = "Potassium", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Manganese = new(new NutrientDto { Name = "Manganese", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Selenium = new(new NutrientDto { Name = "Selenium", Unit = UnitDto.Microgram, Weight = 0 });

	// Amino Acids
	public NutrientWrapper Alanine = new(new NutrientDto { Name = "Alanine", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Arginine = new(new NutrientDto { Name = "Arginine", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Asparagine = new(new NutrientDto { Name = "Asparagine", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper AsparticAcid = new(new NutrientDto { Name = "Aspartic Acid", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Cystine = new(new NutrientDto { Name = "Cystine", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper GlutamicAcid = new(new NutrientDto { Name = "Glutamic Acid", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Glutamine = new(new NutrientDto { Name = "Glutamine", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Glycine = new(new NutrientDto { Name = "Glycine", Unit = UnitDto.Grams, Weight = 0 });
	public NutrientWrapper Histidine = new(new NutrientDto { Name = "Histidine", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Hydroxyproline = new(new NutrientDto { Name = "Hydroxyproline", Unit = UnitDto.Grams, Weight = 0 });
    public NutrientWrapper Isoleucine = new(new NutrientDto { Name = "Isoleucine", Unit = UnitDto.Milligram, Weight = 0 });
    public NutrientWrapper Leucine = new(new NutrientDto { Name = "Leucine", Unit = UnitDto.Milligram, Weight = 0 });
	public NutrientWrapper Lysine = new(new NutrientDto { Name = "Lysine", Unit = UnitDto.Milligram, Weight = 0 });
    public NutrientWrapper Methionine = new(new NutrientDto { Name = "Methionine", Unit = UnitDto.Milligram, Weight = 0 });
    public NutrientWrapper Phenylalanine = new(new NutrientDto { Name = "Phenylalanine", Unit = UnitDto.Milligram, Weight = 0 });
    public NutrientWrapper Proline = new(new NutrientDto { Name = "Proline", Unit = UnitDto.Grams, Weight = 0 }); // Nonessential
    public NutrientWrapper Serine = new(new NutrientDto { Name = "Serine", Unit = UnitDto.Grams, Weight = 0 }); // Nonessential
    public NutrientWrapper Threonine = new(new NutrientDto { Name = "Threonine", Unit = UnitDto.Milligram, Weight = 0 });
    public NutrientWrapper Tryptophan = new(new NutrientDto { Name = "Tryptophan", Unit = UnitDto.Milligram, Weight = 0 });
    public NutrientWrapper Tyrosine = new(new NutrientDto { Name = "Tyrosine", Unit = UnitDto.Grams, Weight = 0 }); // Nonessential
    public NutrientWrapper Valine = new(new NutrientDto { Name = "Valine", Unit = UnitDto.Milligram, Weight = 0 });
	// public static NutrientDto Theobromine => new() { Name = "Theobromine", Unit = UnitDto.Grams, Weight = 0 };

	public List<NutrientWrapper> NutrientList => [Calories, Protein, Carbohydrates, Fiber, Sugars, Starch, Fat, SaturatedFat, TransFat, MonounsaturatedFat, PolyunsaturatedFat, Chloride, Omega3, Omega6, Cholesterol, VitaminA, VitaminD, VitaminE, VitaminC, VitaminK1, VitaminK2, Thiamin, Riboflavin, Niacin, PantothenicAcid, VitaminB6, Biotin, Folate, VitaminB12, TocopherolAlpha, Choline, FolicAcid, CaroteneAlpha, CaroteneBeta, CryptoxanthinBeta, LuteinZeaxanthin, Lycopene, Calcium, Chromium, Iron, Zinc, Sodium, Magnesium, Copper, Fluoride, Iodine, Molybdenum, Nickel, Phosphorus, Potassium, Manganese, Phosphorus, Selenium, Alanine, Arginine, Asparagine, AsparticAcid, Cystine, GlutamicAcid, Glutamine, Glycine, Histidine, Hydroxyproline, Isoleucine, Leucine, Lysine, Methionine, Phenylalanine, Proline, Serine, Threonine, Tryptophan, Tyrosine, Valine];
}

