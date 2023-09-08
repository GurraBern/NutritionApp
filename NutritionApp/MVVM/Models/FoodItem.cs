using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.Models;
using NutritionApp.Models.Nutrition;

namespace NutritionApp.MVVM.Models;

public class FoodItem : ObservableObject
{
    public string? Id { get; set; }

    public string Name { get; set; } = null!;

    public CreatorType CreatorType { get; set; }

    public string ServingSize { get; set; }

    public double Calories { get; set; }

    public double Protein { get; set; }

    public Carbohydrates Carbohydrates { get; set; }

    public Fats Fats { get; set; }

    public Vitamins Vitamins { get; set; }

    public Minerals Minerals { get; set; }

    public FattyAcids FattyAcids { get; set; }

    public AminoAcids AminoAcids { get; set; }

    public OtherNutrients OtherNutrients { get; set; }
}
