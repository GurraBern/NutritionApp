using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Components.Pages.NutritionTarget;

public class Nutrients
{
	public static NutrientDto Calories => new() { Name = "Calories", Unit = UnitDto.Kcal, Weight = 2400 };
	public static NutrientDto Protein => new() { Name = "Protein", Unit = UnitDto.Grams, Weight = 100 };
	public static NutrientDto Carbohydrates => new() { Name = "Carbohydrates", Unit = UnitDto.Grams, Weight = 240 };
	public static NutrientDto Fiber => new() { Name = "Fiber", Unit = UnitDto.Grams, Weight = 41 }; //TODO how much?
	public static NutrientDto Sugars => new() { Name = "Sugars", Unit = UnitDto.Grams, Weight = 30 }; //TODO how much?
	public static NutrientDto Starch => new() { Name = "Starch", Unit = UnitDto.Grams, Weight = 30 }; //TODO how much?
	
	public static NutrientDto Fat => new() { Name = "Fat", Unit = UnitDto.Grams, Weight = 70 };
	public static NutrientDto SaturatedFat => new() { Name = "SaturatedFat", Unit = UnitDto.Grams, Weight = 0 }; // As low as possible
	public static NutrientDto TransFat => new() { Name = "TransFat", Unit = UnitDto.Grams, Weight = 0 }; // As low as possible
	public static NutrientDto MonounsaturatedFat => new() { Name = "MonounsaturatedFat", Unit = UnitDto.Grams, Weight = 0 };
	public static NutrientDto PolyunsaturatedFat => new() { Name = "PolyunsaturatedFat", Unit = UnitDto.Grams, Weight = 0 };
	public static NutrientDto Cholesterol => new() { Name = "Cholesterol", Unit = UnitDto.Grams, Weight = 0 }; // As low as possible
	public static NutrientDto Omega3 => new() { Name = "Omega 3", Unit = UnitDto.Grams, Weight = 1.6 };
	public static NutrientDto Omega6 => new() { Name = "Omega 6", Unit = UnitDto.Grams, Weight = 17 };
	
	// Vitamins
	public static NutrientDto VitaminA => new() { Name = "Vitamin A", Unit = UnitDto.Microgram, Weight = 900 }; 
	public static NutrientDto VitaminC => new() { Name = "Vitamin C", Unit = UnitDto.Milligram, Weight = 90 }; 
	public static NutrientDto VitaminD => new() { Name = "Vitamin D", Unit = UnitDto.Microgram, Weight = 15 }; 
	
	public static NutrientDto VitaminB6 => new() { Name = "Vitamin B6", Unit = UnitDto.Milligram, Weight = 1.3 }; 
	public static NutrientDto VitaminE => new() { Name = "Vitamin E", Unit = UnitDto.Milligram, Weight = 15 }; 
	public static NutrientDto VitaminK1 => new() { Name = "Vitamin K1", Unit = UnitDto.Microgram, Weight = 120 }; //TODO should be combined somehow with K2
	public static NutrientDto VitaminK2 => new() { Name = "Vitamin K2", Unit = UnitDto.Grams, Weight = 120 }; //TODO should be combined somehow with K1
	public static NutrientDto Thiamin => new() { Name = "Thiamin", Unit = UnitDto.Milligram, Weight = 1.2 }; 
	public static NutrientDto Riboflavin => new() { Name = "Riboflavin", Unit = UnitDto.Milligram, Weight = 1.3 }; 
	public static NutrientDto Niacin => new() { Name = "Niacin", Unit = UnitDto.Milligram, Weight = 16 }; 
	public static NutrientDto PantothenicAcid => new() { Name = "Pantothenic Acid", Unit = UnitDto.Milligram, Weight = 5 }; 
	public static NutrientDto Biotin => new() { Name = "Biotin", Unit = UnitDto.Microgram, Weight = 30 }; 
	public static NutrientDto Folate => new() { Name = "Folate", Unit = UnitDto.Microgram, Weight = 400 }; 
	public static NutrientDto VitaminB12 => new() { Name = "Vitamin B12", Unit = UnitDto.Microgram, Weight = 2.4 }; 
	public static NutrientDto TocopherolAlpha => new() { Name = "Tocopherol Alpha", Unit = UnitDto.Grams, Weight = 0 }; 
	public static NutrientDto Choline => new() { Name = "Choline", Unit = UnitDto.Grams, Weight = 0.55 }; 
	public static NutrientDto FolicAcid => new() { Name = "Folic Acid", Unit = UnitDto.Grams, Weight = 0 }; 
	public static NutrientDto CaroteneAlpha => new() { Name = "Carotene Alpha", Unit = UnitDto.Grams, Weight = 0 }; //?
	public static NutrientDto CaroteneBeta => new() { Name = "Carotene Beta", Unit = UnitDto.Grams, Weight = 0 }; //?
	public static NutrientDto CryptoxanthinBeta => new() { Name = "Cryptoxanthin Beta", Unit = UnitDto.Grams, Weight = 0 }; 
	public static NutrientDto LuteinZeaxanthin => new() { Name = "Lutein Zeaxanthin", Unit = UnitDto.Grams, Weight = 0 }; 
	public static NutrientDto Lycopene => new() { Name = "Lycopene", Unit = UnitDto.Grams, Weight = 0 };
	
	// Minerals
	public static NutrientDto Calcium => new() { Name = "Calcium", Unit = UnitDto.Milligram, Weight = 1000 }; 
	public static NutrientDto Chloride => new() { Name = "Chloride", Unit = UnitDto.Grams, Weight = 2.3 }; 
	public static NutrientDto Chromium => new() { Name = "Chromium", Unit = UnitDto.Microgram, Weight = 35 }; 
	public static NutrientDto Iron => new() { Name = "Iron", Unit = UnitDto.Milligram, Weight = 8 };
	public static NutrientDto Zinc => new() { Name = "Zinc", Unit = UnitDto.Milligram, Weight = 11 };
	public static NutrientDto Sodium => new() { Name = "Sodium", Unit = UnitDto.Milligram, Weight = 1500 };
	public static NutrientDto Magnesium => new() { Name = "Magnesium", Unit = UnitDto.Milligram, Weight = 400 };
	public static NutrientDto Copper => new() { Name = "Copper", Unit = UnitDto.Microgram, Weight = 900 };
	public static NutrientDto Fluoride => new() { Name = "Fluoride", Unit = UnitDto.Milligram, Weight = 4 };
	public static NutrientDto Iodine => new() { Name = "Iodine", Unit = UnitDto.Microgram, Weight = 150 };
	public static NutrientDto Molybdenum => new() { Name = "Molybdenum", Unit = UnitDto.Microgram, Weight = 45 };
	public static NutrientDto Nickel => new() { Name = "Nickel", Unit = UnitDto.Milligram, Weight = 1 };
	public static NutrientDto Phosphorus => new() { Name = "Phosphorus", Unit = UnitDto.Grams, Weight = 0.7 };
	public static NutrientDto Potassium => new() { Name = "Potassium", Unit = UnitDto.Milligram, Weight = 3400 };
	public static NutrientDto Manganese => new() { Name = "Manganese", Unit = UnitDto.Milligram, Weight = 2.3 };
	public static NutrientDto Selenium => new() { Name = "Selenium", Unit = UnitDto.Microgram, Weight = 55 };
	// Amino Acids
	public static NutrientDto Alanine => new() { Name = "Alanine", Unit = UnitDto.Grams, Weight = 0 };
	public static NutrientDto Arginine => new() { Name = "Arginine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public static NutrientDto Asparagine => new() { Name = "Asparagine", Unit = UnitDto.Grams, Weight = 0 };
	public static NutrientDto AsparticAcid => new() { Name = "Aspartic Acid", Unit = UnitDto.Grams, Weight = 0 };
	public static NutrientDto Cystine => new() { Name = "Cystine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public static NutrientDto GlutamicAcid => new() { Name = "Glutamic Acid", Unit = UnitDto.Grams, Weight = 0 };
	public static NutrientDto Glutamine => new() { Name = "Glutamine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public static NutrientDto Glycine => new() { Name = "Glycine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public static NutrientDto Histidine => new() { Name = "Histidine", Unit = UnitDto.Milligram, Weight = 952 };
	public static NutrientDto Hydroxyproline => new() { Name = "Hydroxyproline", Unit = UnitDto.Grams, Weight = 0 };
	public static NutrientDto Isoleucine => new() { Name = "Isoleucine", Unit = UnitDto.Milligram, Weight = 1292 };
	public static NutrientDto Leucine => new() { Name = "Leucine", Unit = UnitDto.Milligram, Weight = 2856 };
	public static NutrientDto Lysine => new() { Name = "Lysine", Unit = UnitDto.Milligram, Weight = 2584 };
	public static NutrientDto Methionine => new() { Name = "Methionine", Unit = UnitDto.Milligram, Weight = 1292 };
	public static NutrientDto Phenylalanine => new() { Name = "Phenylalanine", Unit = UnitDto.Milligram, Weight = 2244 };
	public static NutrientDto Proline => new() { Name = "Proline", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public static NutrientDto Serine => new() { Name = "Serine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public static NutrientDto Threonine => new() { Name = "Threonine", Unit = UnitDto.Milligram, Weight = 1360 };
	public static NutrientDto Tryptophan => new() { Name = "Tryptophan", Unit = UnitDto.Milligram, Weight = 340 };
	public static NutrientDto Tyrosine => new() { Name = "Tyrosine", Unit = UnitDto.Grams, Weight = 0 }; // Nonessential
	public static NutrientDto Valine => new() { Name = "Valine", Unit = UnitDto.Milligram, Weight = 1632 };
	// public static NutrientDto Theobromine => new() { Name = "Theobromine", Unit = UnitDto.Grams, Weight = 0 };

	public static List<NutrientDto> List() => 
		[Calories, Protein, Carbohydrates, Fiber, Sugars, Starch, Fat, SaturatedFat, TransFat, MonounsaturatedFat, PolyunsaturatedFat, Chloride, Omega3, Omega6, Cholesterol, VitaminA, VitaminD, VitaminE, VitaminC, VitaminK1, VitaminK2, Thiamin, Riboflavin, Niacin, PantothenicAcid, VitaminB6, Biotin, Folate, VitaminB12, TocopherolAlpha, Choline, FolicAcid, CaroteneAlpha, CaroteneBeta, CryptoxanthinBeta, LuteinZeaxanthin, Lycopene, Calcium, Chromium, Iron, Zinc, Sodium, Magnesium, Copper, Fluoride, Iodine, Molybdenum, Nickel, Phosphorus, Potassium, Manganese, Phosphorus, Selenium, Alanine, Arginine, Asparagine, AsparticAcid, Cystine, GlutamicAcid, Glutamine, Glycine, Histidine, Hydroxyproline, Isoleucine, Leucine, Lysine, Methionine, Phenylalanine, Proline, Serine, Threonine, Tryptophan, Tyrosine, Valine];
}