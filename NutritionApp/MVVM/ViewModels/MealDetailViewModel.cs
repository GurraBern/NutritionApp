using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels
{
    public partial class MealDetailViewModel : BaseViewModel
    {
        private readonly INutritionTracker nutritionTracker;
        private readonly NavigationService navigationService;
        private NutritionDay nutritionDay;
        public ObservableCollection<FoodItem> BreakFastFoodItems { get; } = [];
        public ObservableCollection<FoodItem> LunchFoodItems { get; } = [];
        public ObservableCollection<FoodItem> DinnerFoodItems { get; } = [];
        public ObservableCollection<FoodItem> SnacksFoodItems { get; } = [];
        public Task Initialization { get; private set; }

        public MealDetailViewModel(INutritionTracker nutritionTracker, NavigationService navigationService)
        {
            this.nutritionTracker = nutritionTracker;
            this.navigationService = navigationService;
            Initialization = InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            nutritionDay = await nutritionTracker.GetSelectedNutritionDay();
            UpdateFoodItems();
        }

        private void UpdateFoodItems()
        {
            BreakFastFoodItems.AddRange(nutritionDay.BreakfastFoods);
            LunchFoodItems.AddRange(nutritionDay.LunchFoods);
            DinnerFoodItems.AddRange(nutritionDay.DinnerFoods);
            SnacksFoodItems.AddRange(nutritionDay.SnacksFoods);
        }

        [RelayCommand]
        private void RemoveFoodItem(FoodItem foodItem)
        {
            nutritionTracker.RemoveFood(foodItem);
            UpdateFoodItems();
        }

        [RelayCommand]
        private async Task OpenFoodDetail(FoodItem foodItem)
        {
            await navigationService.NavigateToFoodDetailPage(foodItem);
        }
    }
}