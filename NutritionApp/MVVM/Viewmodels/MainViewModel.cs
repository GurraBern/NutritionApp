using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services;

namespace NutritionApp.MVVM.Viewmodels;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private readonly INutritionService nutritionService;
    public ObservableCollection<FoodItem> SearchResults { get; set; } = new();
  

    public MainViewModel(INutritionService nutritionService)
    {
        this.nutritionService = nutritionService;
    }

    public ICommand PerformSearch => new Command<string>((string query) =>
    {
        var searchResult = nutritionService.GetSearchResults(query);

        if(searchResult != null)
        {
            SearchResults.Clear();
            foreach (var foodItem in searchResult)
            {
                SearchResults.Add(foodItem);
            }
        }

    });

    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
