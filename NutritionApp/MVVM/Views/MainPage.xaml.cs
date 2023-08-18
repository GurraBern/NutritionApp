using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels;

namespace NutritionApp;

public partial class MainPage : ContentPage
{
	private MainViewModel vm;
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		this.vm = vm;
	}

    private async void SearchResultSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var selectedFoodItem = e.SelectedItem as FoodItem;
		await MainViewModel.NavigateToFoodDetailPage(selectedFoodItem);
	}
}

