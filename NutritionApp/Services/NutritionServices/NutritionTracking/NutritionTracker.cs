using CommunityToolkit.Mvvm.ComponentModel;
using Nutrition.Core;
using NutritionApp.Data;

namespace NutritionApp.Services.NutritionServices;

public class NutritionTracker : ObservableObject, INutritionTracker
{
    private int dayIndex = 0;
    private bool isInitialized = false;
    private NutritionDay currentNutritionDay;
    private List<NutritionDay> NutritionDays = [];
    private readonly INutritionTrackingService nutritionDataProvider;
    private readonly ISettingsService settingsService;
    private readonly IDataRepository dataRepository;

    public NutritionTracker(INutritionTrackingService nutritionDataProvider, ISettingsService settingsService, IDataRepository dataRepository)
    {
        this.nutritionDataProvider = nutritionDataProvider;
        this.settingsService = settingsService;
        this.dataRepository = dataRepository;
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
        dataRepository.AddToSearchHistory(food);

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