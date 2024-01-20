using Microcharts;
using NutritionApp.MVVM.ViewModels;
using SkiaSharp;

namespace NutritionApp.MVVM.Views;

public partial class ProgressPage : ContentPage
{
    public ProgressPage(ProgressViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        //TODO Replace with actual entries, binding should be from ViewModel
        var chartEntries = new ChartEntry[]
        {
            new ChartEntry(76)
            {
                Color = SKColor.FromHsl(335,35,54),
                Label = "Jun"
            },
            new ChartEntry(78)
            {
                Color = SKColor.FromHsl(335,35,54),
                Label = "Jul"
            },
            new ChartEntry(74)
            {
                Color = SKColor.FromHsl(335,35,54),
                Label = "Aug"
            },
            new ChartEntry(70)
            {
                Color = SKColor.FromHsl(335,35,54),
                Label = "Sep"
            }
        };

        chartView.Chart = new LineChart()
        {
            Entries = chartEntries,
            BackgroundColor = SKColor.FromHsl(206, 32, 10),
            LineSize = 2,
            PointSize = 10,
            LineMode = LineMode.Spline,
            ShowYAxisLines = true,
            ShowYAxisText = true,
            LabelOrientation = Orientation.Horizontal,
            YAxisPosition = Position.Left,
            MinValue = 67 //TODO Calculate min value over the time period plus some offset(10)
        };
    }
}