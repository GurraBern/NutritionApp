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
