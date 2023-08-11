using NutritionApp.MVVM.Models;

namespace NutritionApp.Services;

public class NutritionService : INutritionService
{

    public NutritionService()
    {
        
    }

    public ICollection<FoodItem> GetSearchResults(string query)
    {
        //TODO implement api call
        var searchResults = new List<FoodItem>();
        var food1 = new FoodItem()
        {
            FoodName = "Pancakes",
            Gram = 100,
            Kcal = 242,
            Protein = 10,
            Carbs = 50,
            Fat = 20
        };

        var food2 = new FoodItem()
        {
            FoodName = "Egg and Bacon",
            Gram = 100,
            Kcal = 194,
            Protein = 20,
            Carbs = 30,
            Fat = 30
        };

        searchResults.Add(food1);
        searchResults.Add(food2);

        return searchResults;
    }
}
