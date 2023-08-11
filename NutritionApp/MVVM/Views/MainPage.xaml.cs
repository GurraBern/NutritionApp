using NutritionApp.MVVM.Viewmodels;
using NutritionApp.Services;

namespace NutritionApp;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

