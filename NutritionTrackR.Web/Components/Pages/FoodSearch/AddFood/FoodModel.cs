using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Components.Pages.FoodSearch.AddFood;

public class FoodModel
{
    public FoodDto Food { get; }
    public decimal Amount { get; set; } = 100;
    public UnitDto Unit { get; set; } = UnitDto.Grams;
    public MealTypeDto MealType { get; set; }
    public FoodModel(FoodDto food, MealTypeDto mealType)
    {
        Food = food;
        MealType = mealType;
    }
    
    public string FoodId => Food.Id;
    public List<NutrientDto> Nutrients { get; set; }
}

public class NutritionModel
{
    public double Carbs { get; set; } 
    public double Protein { get; set; }
    public double Fat { get; set; }
}