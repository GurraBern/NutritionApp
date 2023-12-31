using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;

namespace NutritionApp.MVVM.Views;

public partial class AddFoodPage : ContentPage
{
    private readonly AddFoodViewModel vm;
    private readonly NavigationService navigationService;

    public AddFoodPage(AddFoodViewModel vm, NavigationService navigationService)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
        this.navigationService = navigationService;
    }

    private void searchbar_TextChanged(object sender, TextChangedEventArgs e)
    {
        vm.SearchRecent(searchbar.Text);
    }
}