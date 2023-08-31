using NutritionApp.Services;

namespace NutritionApp.MVVM.Viewmodels;

public class NutritionDetailViewModel
{
    private readonly INutritionTracker nutritionTracker;

    public NutritionDetailViewModel(INutritionTracker nutritionTracker)
    {
        this.nutritionTracker = nutritionTracker;
    }


}
