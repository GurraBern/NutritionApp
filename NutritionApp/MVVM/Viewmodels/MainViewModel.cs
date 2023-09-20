using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices.NutritionService;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;
    private readonly INutritionTracker nutritionTracker;
    public ObservableCollection<FoodItem> SearchResults { get; set; } = new();
    public ObservableCollection<FoodItem> ConsumedFoodItems { get; set; } = new();
    public ObservableCollection<Nutrient> MainNutrients { get; set; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; set; } = new();
    public ObservableCollection<Nutrient> Minerals { get; set; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; set; } = new();

    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;
        InitializeNutrients(nutritionTracker);
    }

    private void InitializeNutrients(INutritionTracker nutritionTracker)
    {
        //Main nutrients
        MainNutrients.Add(new Nutrient("Calories", 1, nutritionTracker.NutrientTotals["Calories"], nutritionTracker));
        MainNutrients.Add(new Nutrient("Protein", 1, nutritionTracker.NutrientTotals["Protein"], nutritionTracker));
        MainNutrients.Add(new Nutrient("Carbohydrates", 1, nutritionTracker.NutrientTotals["Carbohydrates"], nutritionTracker));
        MainNutrients.Add(new Nutrient("Fat", 1, nutritionTracker.NutrientTotals["Fat"], nutritionTracker));
        MainNutrients.Add(new Nutrient("SaturatedFat", 1, nutritionTracker.NutrientTotals["SaturatedFat"], nutritionTracker));
        MainNutrients.Add(new Nutrient("Cholesterol", 1, nutritionTracker.NutrientTotals["Cholesterol"], nutritionTracker));

        ////Vitamins
        Vitamins.Add(new Nutrient("VitaminA", 1, nutritionTracker.NutrientTotals["VitaminA"], nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminD", 1, nutritionTracker.NutrientTotals["VitaminD"], nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminE", 1, nutritionTracker.NutrientTotals["VitaminE"], nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminC", 1, nutritionTracker.NutrientTotals["VitaminC"], nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminK", 1, nutritionTracker.NutrientTotals["VitaminK"], nutritionTracker));
        Vitamins.Add(new Nutrient("Thiamin", 1, nutritionTracker.NutrientTotals["Thiamin"], nutritionTracker));
        Vitamins.Add(new Nutrient("Riboflavin", 1, nutritionTracker.NutrientTotals["Riboflavin"], nutritionTracker));
        Vitamins.Add(new Nutrient("Niacin", 1, nutritionTracker.NutrientTotals["Niacin"], nutritionTracker));
        Vitamins.Add(new Nutrient("PantothenicAcid", 1, nutritionTracker.NutrientTotals["PantothenicAcid"], nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminB6", 1, nutritionTracker.NutrientTotals["VitaminB6"], nutritionTracker));
        Vitamins.Add(new Nutrient("Folate", 1, nutritionTracker.NutrientTotals["Folate"], nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminB12", 1, nutritionTracker.NutrientTotals["VitaminB12"], nutritionTracker));
        Vitamins.Add(new Nutrient("TocopherolAlpha", 1, nutritionTracker.NutrientTotals["TocopherolAlpha"], nutritionTracker));
        Vitamins.Add(new Nutrient("Choline", 1, nutritionTracker.NutrientTotals["Choline"], nutritionTracker));
        Vitamins.Add(new Nutrient("FolicAcid", 1, nutritionTracker.NutrientTotals["FolicAcid"], nutritionTracker));
        Vitamins.Add(new Nutrient("CaroteneAlpha", 1, nutritionTracker.NutrientTotals["CaroteneAlpha"], nutritionTracker));
        Vitamins.Add(new Nutrient("CaroteneBeta", 1, nutritionTracker.NutrientTotals["CaroteneBeta"], nutritionTracker));
        Vitamins.Add(new Nutrient("CryptoxanthinBeta", 1, nutritionTracker.NutrientTotals["CryptoxanthinBeta"], nutritionTracker));
        Vitamins.Add(new Nutrient("LuteinZeaxanthin", 1, nutritionTracker.NutrientTotals["LuteinZeaxanthin"], nutritionTracker));
        Vitamins.Add(new Nutrient("Lycopene", 1, nutritionTracker.NutrientTotals["Lycopene"], nutritionTracker));

        ////Minerals
        Minerals.Add(new Nutrient("Calcium", 1, nutritionTracker.NutrientTotals["Calcium"], nutritionTracker));
        Minerals.Add(new Nutrient("Iron", 1, nutritionTracker.NutrientTotals["Iron"], nutritionTracker));
        Minerals.Add(new Nutrient("Zink", 1, nutritionTracker.NutrientTotals["Zink"], nutritionTracker));
        Minerals.Add(new Nutrient("Sodium", 1, nutritionTracker.NutrientTotals["Sodium"], nutritionTracker));
        Minerals.Add(new Nutrient("Magnesium", 1, nutritionTracker.NutrientTotals["Magnesium"], nutritionTracker));
        Minerals.Add(new Nutrient("Copper", 1, nutritionTracker.NutrientTotals["Copper"], nutritionTracker));
        Minerals.Add(new Nutrient("Manganese", 1, nutritionTracker.NutrientTotals["Manganese"], nutritionTracker));
        Minerals.Add(new Nutrient("Phosphorous", 1, nutritionTracker.NutrientTotals["Phosphorous"], nutritionTracker));
        Minerals.Add(new Nutrient("Selenium", 1, nutritionTracker.NutrientTotals["Selenium"], nutritionTracker));

        ////Amino Acids
        AminoAcids.Add(new Nutrient("Alanine", 1, nutritionTracker.NutrientTotals["Alanine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Arginine", 1, nutritionTracker.NutrientTotals["Arginine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("AsparticAcid", 1, nutritionTracker.NutrientTotals["AsparticAcid"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Cystine", 1, nutritionTracker.NutrientTotals["Cystine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("GlutamicAcid", 1, nutritionTracker.NutrientTotals["GlutamicAcid"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Histidine", 1, nutritionTracker.NutrientTotals["Histidine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Hydroxyproline", 1, nutritionTracker.NutrientTotals["Hydroxyproline"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Isoleucine", 1, nutritionTracker.NutrientTotals["Isoleucine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Leucine", 1, nutritionTracker.NutrientTotals["Leucine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Lysine", 1, nutritionTracker.NutrientTotals["Lysine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Methionine", 1, nutritionTracker.NutrientTotals["Methionine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Phenylalanine", 1, nutritionTracker.NutrientTotals["Phenylalanine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Proline", 1, nutritionTracker.NutrientTotals["Proline"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Serine", 1, nutritionTracker.NutrientTotals["Serine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Threonine", 1, nutritionTracker.NutrientTotals["Threonine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Tryptophan", 1, nutritionTracker.NutrientTotals["Tryptophan"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Tyrosine", 1, nutritionTracker.NutrientTotals["Tyrosine"], nutritionTracker));
        AminoAcids.Add(new Nutrient("Valine", 1, nutritionTracker.NutrientTotals["Valine"], nutritionTracker));
    }

    public void UpdateNutritionInformation()
    {
        UpdateConsumedFoods();
        UpdateConsumedNutrients();
    }

    private void UpdateConsumedFoods()
    {
        ConsumedFoodItems.Clear();

        var consumedFoodItems = nutritionTracker.ConsumedFoods;
        foreach (var foodItem in consumedFoodItems)
        {
            ConsumedFoodItems.Add(foodItem);
        }
    }

    private void UpdateConsumedNutrients()
    {
        foreach (var nutrient in new ObservableCollection<Nutrient>[] { MainNutrients, Vitamins, Minerals, AminoAcids }.SelectMany(list => list))
        {
            nutrient.Update();
        }
    }

    [RelayCommand]
    public async Task PerformSearch(string query)
    {
        if (string.IsNullOrEmpty(query))
            return;

        IsBusy = true;

        var searchResult = await nutritionService.GetSearchResults(query);
        if (searchResult != null)
        {
            SearchResults.Clear();
            foreach (var foodItem in searchResult)
            {
                SearchResults.Add(foodItem);
            }
        }

        IsBusy = false;
    }

    [RelayCommand]
    public void ClearSearchResults()
    {
        SearchResults.Clear();
    }
}
