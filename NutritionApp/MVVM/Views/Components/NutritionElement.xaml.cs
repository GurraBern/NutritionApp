namespace NutritionApp.MVVM.Views;

public partial class NutritionElement : ContentView
{
    public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(NutritionElement), default(string));

    public static readonly BindableProperty AmountProperty =
            BindableProperty.Create(nameof(Amount), typeof(string), typeof(NutritionElement), default(string));

    public static readonly BindableProperty AmountConsumedProperty =
        BindableProperty.Create(nameof(AmountConsumed), typeof(string), typeof(NutritionElement), default(string));

    public static readonly BindableProperty AmountNeededProperty =
           BindableProperty.Create(nameof(AmountNeeded), typeof(string), typeof(NutritionElement), default(string));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Amount
    {
        get
        {
            var amountConsumed = double.Parse((string)GetValue(AmountConsumedProperty));
            var foodNutritionAmount = (string)GetValue(AmountProperty);
            var amountNeeded = int.Parse((string)GetValue(AmountNeededProperty));

            var toBeAddedNutritionIndication = (double.Parse(foodNutritionAmount) + amountConsumed) / amountNeeded;
            MoveProgressBar(addedNutritionProgressBar, toBeAddedNutritionIndication);

            var consumedNutrition = amountConsumed / amountNeeded;
            MoveProgressBar(consumedNutritionProgressBar, consumedNutrition);

            return foodNutritionAmount;
        }
        set => SetValue(AmountProperty, value);
    }

    public string AmountConsumed
    {
        get => (string)GetValue(AmountConsumedProperty);
        set => SetValue(AmountConsumedProperty, value);
    }

    public string AmountNeeded
    {
        get => (string)GetValue(AmountNeededProperty);
        set => SetValue(AmountNeededProperty, value);
    }

    public NutritionElement()
    {
        InitializeComponent();
    }

    private static async void MoveProgressBar(ProgressBar progressBar, double position) => await progressBar.ProgressTo(position, 1000, Easing.Linear);

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        nutritionNameLabel.Text = Text + ": " + Amount;
    }


}
