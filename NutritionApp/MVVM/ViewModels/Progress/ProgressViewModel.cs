using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using Nutrition.Core;
using NutritionApp.Data.Context.Interfaces;
using NutritionApp.Services;
using SkiaSharp;

namespace NutritionApp.MVVM.ViewModels;

public partial class ProgressViewModel : BaseViewModel, IAsyncInitialization
{
    private readonly IUserContext _userContext;
    public IEnumerable<BodyMeasurement> BodyMeasurements { get; set; }
    public TargetMeasurement TargetMeasurements { get; set; }
    public double BMI { get; set; }
    public double WeightProgress { get; set; }

    [ObservableProperty]
    public LineChart lineChart;
    public NavigationService NavigationService { get; }
    public BodyMeasurement BodyMeasurement { get; }

    public Task Initialization { get; private set; }

    public ProgressViewModel(IUserContext userContext, NavigationService navigationService)
    {
        _userContext = userContext;
        NavigationService = navigationService;

        Initialization = InitializationAsync();
    }

    private async Task InitializationAsync()
    {
        try
        {
            var chartEntries = new List<ChartEntry>();
            foreach (var bodyMeasurement in _userContext.BodyMeasurements)
            {
                var chartEntry = new ChartEntry((float)bodyMeasurement.Weight)
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
        catch (Exception ex)
        {
            throw;
        }

    }
}