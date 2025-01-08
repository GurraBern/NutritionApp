using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Web.Shared.FoodSearch.AddFood;

namespace NutritionTrackR.Web.Pages.NutritionTarget;

public class NutrientsModel
{
	public void RecalculateNutrients(List<FoodModel> foods)
	{
		var nutrientDictionary = foods
			.SelectMany(food => food.Nutrients)
			.GroupBy(nutrient => nutrient.Name)
			.ToDictionary(group => group.Key, group => new NutrientDto
			{
				Name = group.Key,
				Weight = group.Sum(nutrient => nutrient.Weight)
			});

		foreach (var nutrient in NutrientList)
		{
			if (nutrientDictionary.TryGetValue(nutrient.Name, out var combinedNutrient))
			{
				nutrient.From(combinedNutrient);
			}
		}
	}
	
	
	//TODO set weight 0 to all
	public NutrientDto Calories = new() { Name = "Calories", Unit = UnitDto.Kcal, Weight = 0 };
	public NutrientDto Protein = new() { Name = "Protein", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto Carbohydrates = new() { Name = "Carbohydrates", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto Fiber = new() { Name = "Fiber", Unit = UnitDto.Grams, Weight = 0 }; //TODO how much?
	public NutrientDto Sugars = new() { Name = "Sugars", Unit = UnitDto.Grams, Weight = 0 }; //TODO how much?
	public NutrientDto Starch = new() { Name = "Starch", Unit = UnitDto.Grams, Weight = 0 }; //TODO how much?
	
	public NutrientDto Fat = new() { Name = "Fat", Unit = UnitDto.Grams, Weight = 70 };
	public NutrientDto SaturatedFat = new() { Name = "SaturatedFat", Unit = UnitDto.Grams, Weight = 0 }; // As low as possible
	public NutrientDto TransFat = new() { Name = "TransFat", Unit = UnitDto.Grams, Weight = 0 }; // As low as possible
	public NutrientDto MonounsaturatedFat = new() { Name = "MonounsaturatedFat", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto PolyunsaturatedFat = new() { Name = "PolyunsaturatedFat", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto Cholesterol = new() { Name = "Cholesterol", Unit = UnitDto.Grams, Weight = 0 }; // As low as possible
	public NutrientDto Omega3 = new() { Name = "Omega 3", Unit = UnitDto.Grams, Weight = 1.6 };
	public NutrientDto Omega6 = new() { Name = "Omega 6", Unit = UnitDto.Grams, Weight = 17 };
	
	// Vitamins
	public NutrientDto VitaminA = new() { Name = "Vitamin A", Unit = UnitDto.Microgram, Weight = 900 }; 
	public NutrientDto VitaminC = new() { Name = "Vitamin C", Unit = UnitDto.Milligram, Weight = 90 }; 
	public NutrientDto VitaminD = new() { Name = "Vitamin D", Unit = UnitDto.Microgram, Weight = 15 }; 
	public NutrientDto VitaminB6 = new() { Name = "Vitamin B6", Unit = UnitDto.Milligram, Weight = 1.3 }; 
	public NutrientDto VitaminE = new() { Name = "Vitamin E", Unit = UnitDto.Milligram, Weight = 15 }; 
	public NutrientDto VitaminK1 = new() { Name = "Vitamin K1", Unit = UnitDto.Microgram, Weight = 120 }; //TODO should be combined somehow with K2
	public NutrientDto VitaminK2 = new() { Name = "Vitamin K2", Unit = UnitDto.Grams, Weight = 120 }; //TODO should be combined somehow with K1
	public NutrientDto Thiamin = new() { Name = "Thiamin", Unit = UnitDto.Milligram, Weight = 1.2 }; 
	public NutrientDto Riboflavin = new() { Name = "Riboflavin", Unit = UnitDto.Milligram, Weight = 1.3 }; 
	public NutrientDto Niacin = new() { Name = "Niacin", Unit = UnitDto.Milligram, Weight = 16 }; 
	public NutrientDto PantothenicAcid = new() { Name = "Pantothenic Acid", Unit = UnitDto.Milligram, Weight = 5 }; 
	public NutrientDto Biotin = new() { Name = "Biotin", Unit = UnitDto.Microgram, Weight = 30 }; 
	public NutrientDto Folate = new() { Name = "Folate", Unit = UnitDto.Microgram, Weight = 400 }; 
	public NutrientDto VitaminB12 = new() { Name = "Vitamin B12", Unit = UnitDto.Microgram, Weight = 2.4 }; 
	public NutrientDto TocopherolAlpha = new() { Name = "Tocopherol Alpha", Unit = UnitDto.Grams, Weight = 0 }; 
	public NutrientDto Choline = new() { Name = "Choline", Unit = UnitDto.Grams, Weight = 0.55 }; 
	public NutrientDto FolicAcid = new() { Name = "Folic Acid", Unit = UnitDto.Grams, Weight = 0 }; 
	public NutrientDto CaroteneAlpha = new() { Name = "Carotene Alpha", Unit = UnitDto.Grams, Weight = 0 }; //?
	public NutrientDto CaroteneBeta = new() { Name = "Carotene Beta", Unit = UnitDto.Grams, Weight = 0 }; //?
	public NutrientDto CryptoxanthinBeta = new() { Name = "Cryptoxanthin Beta", Unit = UnitDto.Grams, Weight = 0 }; 
	public NutrientDto LuteinZeaxanthin = new() { Name = "Lutein Zeaxanthin", Unit = UnitDto.Grams, Weight = 0 }; 
	public NutrientDto Lycopene = new() { Name = "Lycopene", Unit = UnitDto.Grams, Weight = 0 };
	
	// Minerals
	public NutrientDto Calcium = new() { Name = "Calcium", Unit = UnitDto.Milligram, Weight = 1000 }; 
	public NutrientDto Chloride = new() { Name = "Chloride", Unit = UnitDto.Grams, Weight = 2.3 }; 
	public NutrientDto Chromium = new() { Name = "Chromium", Unit = UnitDto.Microgram, Weight = 35 }; 
	public NutrientDto Iron = new() { Name = "Iron", Unit = UnitDto.Milligram, Weight = 8 };
	public NutrientDto Zinc = new() { Name = "Zinc", Unit = UnitDto.Milligram, Weight = 11 };
	public NutrientDto Sodium = new() { Name = "Sodium", Unit = UnitDto.Milligram, Weight = 1500 };
	public NutrientDto Magnesium = new() { Name = "Magnesium", Unit = UnitDto.Milligram, Weight = 400 };
	public NutrientDto Copper = new() { Name = "Copper", Unit = UnitDto.Microgram, Weight = 900 };
	public NutrientDto Fluoride = new() { Name = "Fluoride", Unit = UnitDto.Milligram, Weight = 4 };
	public NutrientDto Iodine = new() { Name = "Iodine", Unit = UnitDto.Microgram, Weight = 150 };
	public NutrientDto Molybdenum = new() { Name = "Molybdenum", Unit = UnitDto.Microgram, Weight = 45 };
	public NutrientDto Nickel = new() { Name = "Nickel", Unit = UnitDto.Milligram, Weight = 1 };
	public NutrientDto Phosphorus = new() { Name = "Phosphorus", Unit = UnitDto.Grams, Weight = 0.7 };
	public NutrientDto Potassium = new() { Name = "Potassium", Unit = UnitDto.Milligram, Weight = 3400 };
	public NutrientDto Manganese = new() { Name = "Manganese", Unit = UnitDto.Milligram, Weight = 2.3 };
	public NutrientDto Selenium = new() { Name = "Selenium", Unit = UnitDto.Microgram, Weight = 55 };
	
	// Amino Acids
	public NutrientDto Alanine = new() { Name = "Alanine", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto Arginine = new() { Name = "Arginine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public NutrientDto Asparagine = new() { Name = "Asparagine", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto AsparticAcid = new() { Name = "Aspartic Acid", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto Cystine = new() { Name = "Cystine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public NutrientDto GlutamicAcid = new() { Name = "Glutamic Acid", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto Glutamine = new() { Name = "Glutamine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public NutrientDto Glycine = new() { Name = "Glycine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public NutrientDto Histidine = new() { Name = "Histidine", Unit = UnitDto.Milligram, Weight = 952 };
	public NutrientDto Hydroxyproline = new() { Name = "Hydroxyproline", Unit = UnitDto.Grams, Weight = 0 };
	public NutrientDto Isoleucine = new() { Name = "Isoleucine", Unit = UnitDto.Milligram, Weight = 1292 };
	public NutrientDto Leucine = new() { Name = "Leucine", Unit = UnitDto.Milligram, Weight = 2856 };
	public NutrientDto Lysine = new() { Name = "Lysine", Unit = UnitDto.Milligram, Weight = 2584 };
	public NutrientDto Methionine = new() { Name = "Methionine", Unit = UnitDto.Milligram, Weight = 1292 };
	public NutrientDto Phenylalanine = new() { Name = "Phenylalanine", Unit = UnitDto.Milligram, Weight = 2244 };
	public NutrientDto Proline = new() { Name = "Proline", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public NutrientDto Serine = new() { Name = "Serine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public NutrientDto Threonine = new() { Name = "Threonine", Unit = UnitDto.Milligram, Weight = 1360 };
	public NutrientDto Tryptophan = new() { Name = "Tryptophan", Unit = UnitDto.Milligram, Weight = 340 };
	public NutrientDto Tyrosine = new() { Name = "Tyrosine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public NutrientDto Valine = new() { Name = "Valine", Unit = UnitDto.Milligram, Weight = 1632 };
	// public static NutrientDto Theobromine => new() { Name = "Theobromine", Unit = UnitDto.Grams, Weight = 0 };

	public List<NutrientDto> NutrientList => [Calories, Protein, Carbohydrates, Fiber, Sugars, Starch, Fat, SaturatedFat, TransFat, MonounsaturatedFat, PolyunsaturatedFat, Chloride, Omega3, Omega6, Cholesterol, VitaminA, VitaminD, VitaminE, VitaminC, VitaminK1, VitaminK2, Thiamin, Riboflavin, Niacin, PantothenicAcid, VitaminB6, Biotin, Folate, VitaminB12, TocopherolAlpha, Choline, FolicAcid, CaroteneAlpha, CaroteneBeta, CryptoxanthinBeta, LuteinZeaxanthin, Lycopene, Calcium, Chromium, Iron, Zinc, Sodium, Magnesium, Copper, Fluoride, Iodine, Molybdenum, Nickel, Phosphorus, Potassium, Manganese, Phosphorus, Selenium, Alanine, Arginine, Asparagine, AsparticAcid, Cystine, GlutamicAcid, Glutamine, Glycine, Histidine, Hydroxyproline, Isoleucine, Leucine, Lysine, Methionine, Phenylalanine, Proline, Serine, Threonine, Tryptophan, Tyrosine, Valine];
}