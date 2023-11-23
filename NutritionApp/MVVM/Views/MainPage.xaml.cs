using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}