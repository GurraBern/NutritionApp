using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class FoodDetailPage : ContentPage
{
    public FoodDetailPage(FoodDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}