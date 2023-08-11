using CommunityToolkit.Mvvm.ComponentModel;

namespace NutritionApp.MVVM.Models;

public class FoodItem : ObservableObject
{
    public string Id { get; set; }
    public string FoodName { get; set; }
    public int Gram { get; set; }
    public int Kcal { get; set; }
    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }
}
