using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class MealDetailView : ContentPage
{
    public MealDetailView(MealDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}