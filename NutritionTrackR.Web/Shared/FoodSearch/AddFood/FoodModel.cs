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

    private List<NutrientDto> GetNutrients()
    {
        return Food.Nutrients.Select(nutrient => new NutrientDto
        {
            Name = nutrient.Name,
            Weight = nutrient.Weight/100 * Amount,
            Unit = nutrient.Unit
        }).ToList();
    }
}
