namespace NutritionApp.MVVM.Views;

public partial class CustomProgressBar : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CustomProgressBar), propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (CustomProgressBar)bindable;
        control.titleLabel.Text = newValue as string;
    });

    public static readonly BindableProperty ProgressAProperty = BindableProperty.Create(nameof(ProgressA), typeof(double), typeof(CustomProgressBar), propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (CustomProgressBar)bindable;
        MoveProgressBar(control.progressBarA, (double)newValue);
    });

    public static readonly BindableProperty ProgressBProperty = BindableProperty.Create(nameof(ProgressB), typeof(double), typeof(CustomProgressBar), propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (CustomProgressBar)bindable;
        MoveProgressBar(control.progressBarB, (double)newValue);
    });

    public string Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }

    public double ProgressA
    {
        get => (double)GetValue(ProgressAProperty);
        set => SetValue(ProgressAProperty, value);
    }

    public double ProgressB
    {
        get => (double)GetValue(ProgressBProperty);
        set => SetValue(ProgressBProperty, value);
    }

    public CustomProgressBar()
    {
        InitializeComponent();
    }

    private static async void MoveProgressBar(ProgressBar progressBar, double position) => await progressBar.ProgressTo(position, 700, Easing.SinIn);
}
