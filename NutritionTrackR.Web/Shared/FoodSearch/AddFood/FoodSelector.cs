﻿using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Shared.FoodSearch.AddFood;

public class FoodSelector
{
    public string ZoneId { get; set; }
    public FoodModel LoggedFoodModel { get; set; }

    public FoodSelector(FoodModel foodModel)
    {
        ZoneId = GetZoneId(foodModel.MealType);
        LoggedFoodModel = foodModel;
    }

    public string DisplayWeight() => $"{LoggedFoodModel.Amount} {LoggedFoodModel.Unit.ToString()}";

    public static MealTypeDto GetMealType(string input) => input switch
    {
        "Breakfast" => MealTypeDto.Breakfast,
        "Lunch" => MealTypeDto.Lunch,
        "Dinner" => MealTypeDto.Dinner,
        "Snacks" => MealTypeDto.Snacks,
        _ => throw new ArgumentException("Invalid meal type", nameof(input))
    };

    private static string GetZoneId(MealTypeDto mealType) => mealType switch
    {
        MealTypeDto.Breakfast => "Breakfast",
        MealTypeDto.Lunch => "Lunch",
        MealTypeDto.Dinner => "Dinner",
        MealTypeDto.Snacks => "Snacks",
        _ => "Snacks"
    };
}
