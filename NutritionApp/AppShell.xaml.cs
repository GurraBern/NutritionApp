using NutritionApp.MVVM.Views;

namespace NutritionApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
        Routing.RegisterRoute(nameof(NutritionDetailPage), typeof(NutritionDetailPage));
        Routing.RegisterRoute(nameof(MealDetailView), typeof(MealDetailView));
    }
}