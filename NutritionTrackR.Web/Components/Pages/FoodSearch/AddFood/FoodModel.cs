using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Components.Pages.FoodSearch.AddFood;

public class FoodModel(FoodDto food, Guid? loggedFoodId = default)
{
    public FoodDto Food { get; } = food;
    public decimal Amount { get; set; } = new(food.Amount);
    public UnitDto Unit { get; set; } = UnitDto.Grams;
    public Guid? LoggedFoodId { get; set; } = loggedFoodId;

    public string FoodId => Food.Id;
    public string Name => Food.Name;
    public MealTypeDto MealType => Food.MealType;
    public List<NutrientDto> Nutrients => Food.Nutrients;
}

public class NutritionModel
{
    public double Carbs { get; set; } 
    public double Protein { get; set; }
    public double Fat { get; set; }
}