using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Food.Events;

// TODO when projecting data grab the food items and calculate the nutritional values
public class FoodEntryAdded : BaseDomainEvent
{
    public string FoodId { get; private set; } //TODO to value object
    public Weight Weight { get; private set; }
    public Unit Unit { get; private set; }
    public MealType MealType { get; private set; } 
}

public enum MealType
{
    Unclassified,
    Breakfast,
    Lunch,
    Dinner,
    Snack
}