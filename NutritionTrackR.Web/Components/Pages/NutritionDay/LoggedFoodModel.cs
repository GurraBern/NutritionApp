using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Web.Components.Pages.FoodSearch.AddFood;

namespace NutritionTrackR.Web.Components.Pages.NutritionDay;

public class LoggedFoodModel : FoodModel
{
    public string LoggedFoodId { get; set; }
    
    public LoggedFoodModel(FoodDto food, MealTypeDto mealType) : base(food, mealType) { }
    public LoggedFoodModel(FoodDto food) : base(food, food.MealType) { }
}