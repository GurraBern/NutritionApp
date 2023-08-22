namespace NutritionApp.MVVM.Views;

public partial class NutritionElement : ContentView
{
    public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(NutritionElement), default(string));

    public static readonly BindableProperty AmountProperty =
            BindableProperty.Create(nameof(Amount), typeof(string), typeof(NutritionElement), default(string));

    public static readonly BindableProperty AmountNeededProperty =
           BindableProperty.Create(nameof(AmountNeeded), typeof(string), typeof(NutritionElement), default(string));
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Amount
    {
        get => (string)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }

    public string AmountNeeded
    {
        get => (string)GetValue(AmountNeededProperty);
        set => SetValue(AmountNeededProperty, value);
    }

    public NutritionElement()
	{
        InitializeComponent();

        //TODO Rewrite with actual Amount and AmountNeeded
        Random random = new Random();
        var num = random.NextDouble() * (1 - 0) + 0;

        MoveProgressBar(num);
    }

    private async void MoveProgressBar(double position = 0)
    {
        await nutritionProgressBar.ProgressTo(position, 2000, Easing.Linear);
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        nutritionNameLabel.Text = Text + ": " + Amount;
    }
}