using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Shared.FoodSearch.AddFood;

public class FoodModel(FoodDto food, Guid? loggedFoodId = null)
{
    public FoodDto Food { get; } = food;
    public double Amount { get; set; } = 100;
    public Unit Unit { get; set; }
    public Guid? LoggedFoodId { get; set; } = loggedFoodId;

    public string FoodId => Food.Id;
    public string Name => Food.Name;
    public MealTypeDto MealType => Food.MealType;
    public List<NutrientDto> Nutrients => GetNutrients();

    //TODO make dictionary
    private List<NutrientDto> GetNutrients() =>
        Food.Nutrients.Select(nutrient => new NutrientDto
        {
            Name = nutrient.Name,
            Weight = nutrient.Weight/100*Amount,
            Unit = nutrient.Unit
        }).ToList();

    public List<NutrientDto> CoreNutrients => GetNutrients().Where(x => x.Name is "Carbohydrates" or "Fat" or "Protein").ToList();

    public List<NutrientDto> Vitamins => GetNutrients().Where(x => x.Name is 
        "Vitamin A" or "Vitamin C" or "Vitamin D" or "Vitamin B6" or "Vitamin E" or 
        "Vitamin K1" or "Vitamin K2" or "Thiamin" or "Riboflavin" or "Niacin" or 
        "Pantothenic Acid" or "Biotin" or "Folate" or "Vitamin B12" or 
        "Tocopherol Alpha" or "Choline" or "Folic Acid" or "Carotene Alpha" or 
        "Carotene Beta" or "Cryptoxanthin Beta" or "Lutein Zeaxanthin" or 
        "Lycopene").ToList();

    public List<NutrientDto> Minerals => GetNutrients().Where(x => x.Name is 
        "Calcium" or "Chloride" or "Chromium" or "Iron" or "Zinc" or 
        "Sodium" or "Magnesium" or "Copper" or "Fluoride" or "Iodine" or 
        "Molybdenum" or "Nickel" or "Phosphorus" or "Potassium" or 
        "Manganese" or "Selenium").ToList();

    public List<NutrientDto> AminoAcids => GetNutrients().Where(x => x.Name is 
        "Alanine" or "Arginine" or "Asparagine" or "Aspartic Acid" or "Cystine" or 
        "Glutamic Acid" or "Glutamine" or "Glycine" or "Histidine" or 
        "Hydroxyproline" or "Isoleucine" or "Leucine" or "Lysine" or 
        "Methionine" or "Phenylalanine" or "Proline" or "Serine" or 
        "Threonine" or "Tryptophan" or "Tyrosine" or "Valine").ToList();
}