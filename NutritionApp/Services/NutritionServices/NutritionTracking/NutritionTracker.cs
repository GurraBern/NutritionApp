using CommunityToolkit.Mvvm.ComponentModel;
using Nutrition.Core;

namespace NutritionApp.Services.NutritionServices;

public class NutritionTracker : ObservableObject, INutritionTracker
{
    private int dayIndex = 0;
    private bool isInitialized = false;
    private NutritionDay currentNutritionDay;
    private List<NutritionDay> NutritionDays = [];
    private readonly INutritionTrackingService nutritionDataProvider;
    private readonly ISettingsService settingsService;

    public NutritionTracker(INutritionTrackingService nutritionDataProvider, ISettingsService settingsService)
    {
        this.nutritionDataProvider = nutritionDataProvider;
        this.settingsService = settingsService;
    }

    public async Task Initialize()
    {
        if (!isInitialized)
        {
            await SetupNutritionDay();

            isInitialized = true;
        }
    }

    public async Task SetupNutritionDay()
    {
        currentNutritionDay = await nutritionDataProvider.GetNutritionDay(DateTime.UtcNow);
        NutritionDays.Add(currentNutritionDay);
    }

    public async void AddFood(FoodItem food)
    {
        var mealPeriod = settingsService.GetMealPeriod(food.MealOfDay);
        if (mealPeriod != null)
        {
            currentNutritionDay.AddFood(food);
            await nutritionDataProvider.SaveNutritionDay(currentNutritionDay);
        }
    }

    public void RemoveFood(FoodItem food)
    {
        //nutritionDay.Remove(food);
    }

    public NutritionDay NextDay()
    {
        dayIndex--;
        if (dayIndex < 0)
            dayIndex = 0;

        currentNutritionDay = NutritionDays[dayIndex];
        return currentNutritionDay;
    }

    public async Task<NutritionDay> PreviousDay()
    {
        dayIndex++;
        if (dayIndex >= NutritionDays.Count)
        {
            var nutritionDay = await nutritionDataProvider.GetNutritionDay(DateTime.UtcNow.AddDays(-dayIndex));
            NutritionDays.Add(nutritionDay);
        }

        currentNutritionDay = NutritionDays[dayIndex];
        return currentNutritionDay;
    }

    public async Task<NutritionDay> GetSelectedNutritionDay()
    {
        await Initialize();

        return currentNutritionDay;
    }
}