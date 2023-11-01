namespace NutritionApp.MVVM.Views;

public partial class CustomProgressBar : ContentView
{
    public static readonly BindableProperty ProgressAProperty = BindableProperty.Create(nameof(ProgressA), typeof(double), typeof(CustomProgressBar), propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (CustomProgressBar)bindable;
        control.progressBarA.Progress = (double)newValue;
    });

    public static readonly BindableProperty ProgressBProperty = BindableProperty.Create(nameof(ProgressB), typeof(double), typeof(CustomProgressBar), propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (CustomProgressBar)bindable;
        control.progressBarB.Progress = (double)newValue;
    });

    public static readonly BindableProperty ProgressBarAColorProperty =
    BindableProperty.Create(nameof(ProgressBarAColor), typeof(Color), typeof(CustomProgressBar), Color.FromRgb(0, 0, 0),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (CustomProgressBar)bindable;
            control.progressBarA.ProgressColor = (Color)newValue;
        });

    public Color ProgressBarAColor
    {
        get { return (Color)GetValue(ProgressBarAColorProperty); }
        set { SetValue(ProgressBarAColorProperty, value); }
    }

    public static readonly BindableProperty ProgressBarBColorProperty =
    BindableProperty.Create(nameof(ProgressBarBColor), typeof(Color), typeof(CustomProgressBar), Color.FromRgb(0, 0, 0),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (CustomProgressBar)bindable;
            control.progressBarB.ProgressColor = (Color)newValue;
        });

    public Color ProgressBarBColor
    {
        get { return (Color)GetValue(ProgressBarBColorProperty); }
        set { SetValue(ProgressBarBColorProperty, value); }
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

    private async static void MoveProgressBar(ProgressBar progressBar, double position) => await progressBar.ProgressTo(position, 500, Easing.Linear);
}
