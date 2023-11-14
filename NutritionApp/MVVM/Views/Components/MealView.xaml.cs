using Nutrition.Core;

namespace NutritionApp.MVVM.Views;

public partial class MealView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MealView), propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (MealView)bindable;
        control.mealTitle.Text = (string)newValue;
    });

    public static readonly BindableProperty MealProperty = BindableProperty.Create(nameof(Meal), typeof(IEnumerable<FoodItem>), typeof(MealView), propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (MealView)bindable;
        control.foodList.ItemsSource = (IEnumerable<FoodItem>)newValue;
    });

    public MealView()
    {
        InitializeComponent();
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public IEnumerable<FoodItem> Meal
    {
        get => (IEnumerable<FoodItem>)GetValue(MealProperty);
        set => SetValue(MealProperty, value);
    }
}
