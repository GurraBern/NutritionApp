using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
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

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await vm.AssignNutritionDay();
        vm.ClearSearchResults();
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
