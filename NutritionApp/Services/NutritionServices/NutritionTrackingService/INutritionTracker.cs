using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices.NutritionTrackingService;

public interface INutritionTracker
{
    public event EventHandler ItemAdded;
    public List<FoodItem> ConsumedFoods { get; set; }
    public double TotalKcal => ConsumedFoods.Sum(food => food.Calories);
    public double TotalProtein => ConsumedFoods.Sum(food => food.Protein);
    public double TotalCarbs => ConsumedFoods.Sum(food => food.Carbohydrates.Carbohydrate);
    public double TotalFat => ConsumedFoods.Sum(food => food.Fats.TotalFat);
    public double TotalSaturatedFat => ConsumedFoods.Sum(food => food.Fats.SaturatedFat);
    public double TotalCholesterol => ConsumedFoods.Sum(food => food.Fats.Cholesterol);
    public double TotalVitaminA => ConsumedFoods.Sum(food => food.Vitamins.VitaminA);
    public double TotalVitaminD => ConsumedFoods.Sum(food => food.Vitamins.VitaminD);
    public double TotalVitaminE => ConsumedFoods.Sum(food => food.Vitamins.VitaminE);
    public double TotalVitaminC => ConsumedFoods.Sum(food => food.Vitamins.VitaminC);
    public double TotalVitaminK => ConsumedFoods.Sum(food => food.Vitamins.VitaminK);
    public double TotalThiamin => ConsumedFoods.Sum(food => food.Vitamins.Thiamin);
    public double TotalRiboflavin => ConsumedFoods.Sum(food => food.Vitamins.Riboflavin);
    public double TotalNiacin => ConsumedFoods.Sum(food => food.Vitamins.Niacin);
    public double TotalPantothenicAcid => ConsumedFoods.Sum(food => food.Vitamins.PantothenicAcid);
    public double TotalVitaminB6 => ConsumedFoods.Sum(food => food.Vitamins.VitaminB6);
    public double TotalFolate => ConsumedFoods.Sum(food => food.Vitamins.Folate);
    public double TotalVitaminB12 => ConsumedFoods.Sum(food => food.Vitamins.VitaminB12);
    public double TotalTocopherolAlpha => ConsumedFoods.Sum(food => food.Vitamins.TocopherolAlpha);
    public double TotalCholine => ConsumedFoods.Sum(food => food.Vitamins.Choline);
    public double TotalFolicAcid => ConsumedFoods.Sum(food => food.Vitamins.FolicAcid);
    public double TotalCaroteneAlpha => ConsumedFoods.Sum(food => food.Vitamins.CaroteneAlpha);
    public double TotalCaroteneBeta => ConsumedFoods.Sum(food => food.Vitamins.CaroteneBeta);
    public double TotalCryptoxanthinBeta => ConsumedFoods.Sum(food => food.Vitamins.CryptoxanthinBeta);
    public double TotalLuteinZeaxanthin => ConsumedFoods.Sum(food => food.Vitamins.LuteinZeaxanthin);
    public double TotalLycopene => ConsumedFoods.Sum(food => food.Vitamins.Lycopene);
    public double TotalCalcium => ConsumedFoods.Sum(food => food.Minerals.Calcium);
    public double TotalIron => ConsumedFoods.Sum(food => food.Minerals.Iron);
    public double TotalZink => ConsumedFoods.Sum(food => food.Minerals.Zink);
    public double TotalSodium => ConsumedFoods.Sum(food => food.Minerals.Sodium);
    public double TotalMagnesium => ConsumedFoods.Sum(food => food.Minerals.Magnesium);
    public double TotalCopper => ConsumedFoods.Sum(food => food.Minerals.Copper);
    public double TotalManganese => ConsumedFoods.Sum(food => food.Minerals.Manganese);
    public double TotalPhosphorous => ConsumedFoods.Sum(food => food.Minerals.Phosphorous);
    public double TotalSelenium => ConsumedFoods.Sum(food => food.Minerals.Selenium);

    

    public void AddFood(FoodItem food);
    public void RemoveFood(FoodItem food);
}
