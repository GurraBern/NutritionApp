using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels;
using NutritionApp.Services;

namespace NutritionApp;

public partial class MainPage : ContentPage
{
    private MainViewModel vm;
    private readonly NavigationService navigationService;

    public MainPage(MainViewModel vm, NavigationService navigationService)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
        this.navigationService = navigationService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        vm.ClearSearchResults();
        vm.UpdateConsumedFoodItems();
    }

    private async void SearchResultSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedFoodItem = e.SelectedItem as FoodItem;
        await navigationService.NavigateToFoodDetailPage(selectedFoodItem);
    }

    private void SearchBar_Unfocused(object sender, FocusEventArgs e)
    {
        vm.ClearSearchResults();
    }
}
