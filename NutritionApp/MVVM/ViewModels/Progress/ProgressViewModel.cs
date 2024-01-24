using Microcharts;
using Nutrition.Core;
using NutritionApp.Components;
using NutritionApp.Services;
using SkiaSharp;

namespace NutritionApp.MVVM.ViewModels;

public class ProgressViewModel
{
    private readonly UserDetails userDetails;
    public IEnumerable<BodyMeasurement> BodyMeasurements { get; set; }
    public TargetMeasurements TargetMeasurements { get; set; }
    public double BMI { get; set; }
    public double WeightProgress { get; set; }
    public LineChart LineChart { get; set; }
    public NavigationService NavigationService { get; }
    public BodyMeasurement BodyMeasurement { get; }

    public ProgressViewModel(UserDetails userDetails, NavigationService navigationService)
    {
        this.userDetails = userDetails;
        NavigationService = navigationService;
        BodyMeasurements = userDetails.BodyMeasurements;
        TargetMeasurements = userDetails.TargetMeasurements;
        BMI = userDetails.BMI;
        BodyMeasurement = BodyMeasurements.FirstOrDefault();

        SetupWeightProgressGraph();
    }

    private void SetupWeightProgressGraph()
    {
        var chartEntries = new List<ChartEntry>();
        foreach (var measurement in BodyMeasurements)
        {
            var chartEntry = new ChartEntry((float)measurement.Weight)
            {
                Color = SKColor.FromHsl(335, 35, 54),
            };

            chartEntries.Add(chartEntry);
        }

        LineChart = new LineChart()
        {
            Entries = chartEntries,
            BackgroundColor = SKColors.Transparent,
            LabelColor = SKColors.White,
            LineSize = 3,
            ValueLabelOrientation = Orientation.Horizontal,
            ShowYAxisLines = true,
            ShowYAxisText = true,
            ValueLabelTextSize = 6,
            LineAreaAlpha = 0,
            PointMode = PointMode.Circle,
            PointSize = 5,
            YAxisMaxTicks = 5,
            LabelOrientation = Orientation.Horizontal,
            ValueLabelOption = ValueLabelOption.None,
            EnableYFadeOutGradient = true,
            YAxisTextPaint = new SKPaint
            {
                TextSize = 16.0f,
                Color = SKColors.White,
                Style = SKPaintStyle.Fill
            },
            LabelTextSize = 25,
            IsAnimated = false,
            AnimationDuration = TimeSpan.Zero,
            MinValue = 67,
            YAxisPosition = Position.Left
        };
    }
}