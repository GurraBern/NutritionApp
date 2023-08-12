using NutritionApp.MVVM.Viewmodels;
using NutritionApp.Services;

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

    private void SearchResultSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var test = e.SelectedItem;
    }
}

