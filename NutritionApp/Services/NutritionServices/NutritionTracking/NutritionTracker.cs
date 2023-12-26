using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Nutrition.Core;
using NutritionApp.Data;

namespace NutritionApp.Services.NutritionServices;

public class NutritionTracker(INutritionTrackingService nutritionDataProvider, ISettingsService settingsService, IDataRepository dataRepository) : ObservableObject, INutritionTracker
{
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
        currentNutritionDay = await nutritionDataProvider.GetNutritionDay(DateTime.UtcNow);
        NutritionDays.Add(currentNutritionDay);
    }

    public async void AddFood(FoodItem food)
    {
        dataRepository.AddToSearchHistory(food);

        food.MealOfDay = settingsService.GetCurrentMealPeriod();

        currentNutritionDay.AddFood(food);
        await nutritionDataProvider.SaveNutritionDay(currentNutritionDay);

        WeakReferenceMessenger.Default.Send(food);
    }

    public void RemoveFood(FoodItem food)
    {
        currentNutritionDay.RemoveFood(food);

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