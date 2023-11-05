using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class NutritionDetailPage : ContentPage
{
    private readonly NutritionDetailViewModel vm;

    public NutritionDetailPage(NutritionDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.UpdateNutritionInformation();
        await vm.ShowBasicNutrients();
    }
}