using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class AddWeightPage : ContentPage
{
    public AddWeightPage(AddWeightViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}