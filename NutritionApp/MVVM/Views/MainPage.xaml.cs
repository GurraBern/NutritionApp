using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;

namespace NutritionApp.MVVM.Views;

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
        vm.UpdateNutritionInformation();

        vm.ClearSearchResults();
    }

    private async void NavigateToNutritionDetails(object sender, TappedEventArgs e)
    {
        await navigationService.NavigateToNutritionDetails();
    }

    private async void NavigateToAddFoodPage(object sender, EventArgs e)
    {
        await navigationService.NavigateToAddFoodPage();

    }
}
