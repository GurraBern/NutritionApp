using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}