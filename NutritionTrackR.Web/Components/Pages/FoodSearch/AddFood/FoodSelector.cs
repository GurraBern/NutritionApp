using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Components.Pages.FoodSearch.AddFood;

public class FoodSelector : FoodDto
{
    public string ZoneId { get; set; }

    public FoodSelector(FoodDto foodDto)
    {
        ZoneId = GetZoneId(foodDto.MealType);
        Name = foodDto.Name;
        Nutrients = foodDto.Nutrients;
        Amount = foodDto.Amount;
        Unit = foodDto.Unit;
        MealType = foodDto.MealType;
    }

    public string DisplayWeight() => $"{Amount} {Unit.ToString()}";

    public static MealTypeDto GetMealType(string input) => input switch
    {
        "Breakfast" => MealTypeDto.Breakfast,
        "Lunch" => MealTypeDto.Lunch,
        "Dinner" => MealTypeDto.Dinner,
        "Snacks" => MealTypeDto.Snack,
        _ => throw new ArgumentException("Invalid meal type", nameof(input))
    };

    public static string GetZoneId(MealTypeDto mealType) => mealType switch
    {
        MealTypeDto.Breakfast => "Breakfast",
        MealTypeDto.Lunch => "Lunch",
        MealTypeDto.Dinner => "Dinner",
        MealTypeDto.Snack => "Snacks"
    };
}
