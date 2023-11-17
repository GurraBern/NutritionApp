using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel vm;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await vm.AssignNutritionDay();
        vm.UpdateNutritionInformation();
        vm.ClearSearchResults();
    }
}
