using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class NutritionDetailPage : ContentPage
{
    public NutritionDetailPage(NutritionDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}