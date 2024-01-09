using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels
{
    public partial class MealDetailViewModel : BaseViewModel, IRecipient<FoodItem>
    {
        private readonly INutritionTracker nutritionTracker;
        private readonly NavigationService navigationService;
        private NutritionDay nutritionDay;
        public ObservableCollection<FoodItem> BreakFastFoodItems { get; } = [];
        public ObservableCollection<FoodItem> LunchFoodItems { get; } = [];
        public ObservableCollection<FoodItem> DinnerFoodItems { get; } = [];
        public ObservableCollection<FoodItem> SnacksFoodItems { get; } = [];
        public NutrientModel Protein { get; }
        public NutrientModel Carbohydrates { get; }
        public NutrientModel Fat { get; }
        public NutrientModel Calories { get; }
        public Task Initialization { get; private set; }

        public MealDetailViewModel(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory, NavigationService navigationService)
        {
            this.nutritionTracker = nutritionTracker;
            this.navigationService = navigationService;
            WeakReferenceMessenger.Default.Register(this);

            Protein = nutrientFactory.CreateNutrient("Protein");
            Carbohydrates = nutrientFactory.CreateNutrient("Carbohydrates");
            Carbohydrates.CustomName = "Carbs";
            Fat = nutrientFactory.CreateNutrient("Fat");
            Calories = nutrientFactory.CreateNutrient("Calories");

            Initialization = InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            nutritionDay = await nutritionTracker.GetSelectedNutritionDay();
            UpdateFoodItems();
            UpdateNutritionInformation();
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
            await navigationService.NavigateToFoodDetailPage(foodItem, PageMode.Edit);
        }

        private void UpdateNutritionInformation()
        {
            Protein.SetProgress(nutritionDay.NutrientTotals[Protein.Name], nutritionDay.NutrientTotals[Protein.Name]);
            Carbohydrates.SetProgress(nutritionDay.NutrientTotals[Carbohydrates.Name], nutritionDay.NutrientTotals[Carbohydrates.Name]);
            Fat.SetProgress(nutritionDay.NutrientTotals[Fat.Name], nutritionDay.NutrientTotals[Fat.Name]);
            Calories.SetProgress(nutritionDay.NutrientTotals[Calories.Name], nutritionDay.NutrientTotals[Calories.Name]);
        }

        public void Receive(FoodItem message)
        {
            UpdateNutritionInformation();
        }
    }
}