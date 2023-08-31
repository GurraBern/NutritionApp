using NutritionApp.MVVM.Viewmodels;

namespace NutritionApp.MVVM.Views.Components;

public partial class NutritionDetailPage : ContentView
{
    public NutritionDetailPage(NutritionDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}