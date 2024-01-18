using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class ProgressPage : ContentPage
{
    public ProgressPage(ProgressViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}