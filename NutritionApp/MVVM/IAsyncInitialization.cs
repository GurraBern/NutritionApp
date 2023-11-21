namespace NutritionApp.MVVM;

public interface IAsyncInitialization
{
    Task Initialization { get; }
}