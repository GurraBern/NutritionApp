using NutritionApp.MVVM.Views;

namespace NutritionApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
    }
}
