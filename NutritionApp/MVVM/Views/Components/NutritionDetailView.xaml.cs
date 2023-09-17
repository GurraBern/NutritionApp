using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;

namespace NutritionApp.MVVM.Views;

public partial class NutritionDetailPage : ContentView
{
    private readonly NutritionDetailViewModel vm;

    public NutritionDetailPage()
    {
        var nutritionTracker = ServiceHelper.GetService<INutritionTracker>();
        vm = new NutritionDetailViewModel(nutritionTracker);

        InitializeComponent();
        BindingContext = vm;
    }
}