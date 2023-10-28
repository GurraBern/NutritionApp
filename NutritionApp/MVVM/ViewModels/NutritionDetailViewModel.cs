using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels.Utils;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public class NutritionDetailViewModel : BaseViewModel
{
    private readonly INutrientFactory nutrientFactory;

    public ObservableCollection<Nutrient> PrimaryNutrients { get; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; } = new();
    public ObservableCollection<Nutrient> Minerals { get; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; } = new();
    public NutritionDetailViewModel(INutrientFactory nutrientFactory)
    {
        this.nutrientFactory = nutrientFactory;

        SetupNutrients(NutritionUtils.mainNutrients, PrimaryNutrients);
        SetupNutrients(NutritionUtils.vitamins, Vitamins);
        SetupNutrients(NutritionUtils.minerals, Minerals);
        SetupNutrients(NutritionUtils.aminoAcids, AminoAcids);
    }

    private void SetupNutrients(List<string> nutrientNames, ObservableCollection<Nutrient> nutrientCollection)
    {
        foreach (var name in nutrientNames)
        {
            var nutrient = nutrientFactory.CreateNutrient(name);
            nutrientCollection.Add(nutrient);
        }
    }

    public void UpdateNutritionInformation()
    {
        foreach (var nutrient in PrimaryNutrients.Concat(Vitamins).Concat(Minerals).Concat(AminoAcids))
        {
            //nutrient.SetProgress(SelectedNutritionDay.NutrientTotals[nutrient.Name], SelectedNutritionDay.NutrientTotals[nutrient.Name]);
        }
    }
}
