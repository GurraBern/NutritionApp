using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Shared.FoodSearch.AddFood;

public class FoodModel(FoodDto food, Guid? loggedFoodId = null)
{
    public FoodDto Food { get; } = food;
    public decimal Amount { get; set; } = new(100);
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
            Weight = nutrient.Weight/100 * Food.Amount,
            Unit = nutrient.Unit
        }).ToList();
    }
}

public class NutritionModel
{
    public double Carbs { get; set; } 
    public double Protein { get; set; }
    public double Fat { get; set; }
}