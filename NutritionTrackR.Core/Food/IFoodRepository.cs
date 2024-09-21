namespace NutritionTrackR.Core.Food;

public interface IFoodRepository
{
    Task CreateFood(Food food);
}