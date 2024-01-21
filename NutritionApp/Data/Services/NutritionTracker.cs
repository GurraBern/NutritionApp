using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Nutrition.Core;

namespace NutritionApp.Data.Services;

public class NutritionTracker(INutritionTrackingService nutritionTrackingService, ISettingsService settingsService, IDataRepository dataRepository) : ObservableObject, INutritionTracker
{
    private readonly INutritionTrackingService _nutritionTrackingService = nutritionTrackingService;
    private readonly ISettingsService _settingsService = settingsService;
    private readonly IDataRepository _dataRepository = dataRepository;
    private int dayIndex = 0;
    private bool isInitialized = false;
    private NutritionDay currentNutritionDay;
    private readonly List<NutritionDay> NutritionDays = [];

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
        currentNutritionDay = await _nutritionTrackingService.GetNutritionDay(DateTime.UtcNow);
        NutritionDays.Add(currentNutritionDay);
    }

    public async Task AddFood(FoodItem food)
    {
        _dataRepository.AddToSearchHistory(food);

        if (food.MealOfDay == MealOfDay.NoClassification)
            food.MealOfDay = _settingsService.GetCurrentMealPeriod();

        currentNutritionDay.AddFood(food);
        await _nutritionTrackingService.SaveNutritionDay(currentNutritionDay);

        WeakReferenceMessenger.Default.Send(food);
    }

    public async Task RemoveFood(FoodItem food)
    {
        currentNutritionDay.RemoveFood(food);
        await _nutritionTrackingService.SaveNutritionDay(currentNutritionDay);

        WeakReferenceMessenger.Default.Send(food);
    }

    public async Task UpdateFood(FoodItem food)
    {
        currentNutritionDay.RemoveFood(food);
        currentNutritionDay.AddFood(food);

        await _nutritionTrackingService.SaveNutritionDay(currentNutritionDay);

        WeakReferenceMessenger.Default.Send(food);
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
            var nutritionDay = await _nutritionTrackingService.GetNutritionDay(DateTime.UtcNow.AddDays(-dayIndex));
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