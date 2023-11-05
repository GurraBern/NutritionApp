using NutritionApp.MVVM.Models;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.Viewmodels.Utils;

public static class ListExtensions
{
    public static void AddRange<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> list)
    {
        observableCollection.Clear();
        foreach (var nutrient in list)
        {
            observableCollection.Add(nutrient);
        }
    }

    public static void SortByNutritionProgress(this ObservableCollection<Nutrient> observableCollection)
    {
        var sortedList = observableCollection
            .OrderByDescending(nu => nu.NutritionProgress)
            .ToList();

        observableCollection.AddRange(sortedList);
    }
}
