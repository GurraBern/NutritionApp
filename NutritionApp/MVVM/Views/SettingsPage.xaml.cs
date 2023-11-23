using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}