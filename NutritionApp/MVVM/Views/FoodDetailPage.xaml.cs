using NutritionApp.MVVM.Viewmodels;

namespace NutritionApp.MVVM.Views;

public partial class FoodDetailPage : ContentPage
{
	public FoodDetailPage(FoodDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}