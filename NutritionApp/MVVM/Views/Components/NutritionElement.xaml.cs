namespace NutritionApp.MVVM.Views;

public partial class NutritionElement : ContentView
{
    public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(NutritionElement), default(string));

    public static readonly BindableProperty AmountProperty =
            BindableProperty.Create(nameof(Amount), typeof(string), typeof(NutritionElement), default(string));

    
    public string Amount
    {
        get => (string)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public NutritionElement()
	{
        InitializeComponent();
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        nutritionNameLabel.Text = Text + ": " + Amount;
    }
}