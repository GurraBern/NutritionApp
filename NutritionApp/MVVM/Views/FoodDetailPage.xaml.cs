using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class FoodDetailPage : ContentPage
{
    private readonly FoodDetailViewModel vm;

    public FoodDetailPage(FoodDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await vm.Initialize();
    }
}