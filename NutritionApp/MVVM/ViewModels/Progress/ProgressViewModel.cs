using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microcharts;
using Nutrition.Core;
using NutritionApp.Data.Context.Interfaces;
using NutritionApp.MVVM.Models;
using NutritionApp.Services;
using SkiaSharp;

namespace NutritionApp.MVVM.ViewModels;

public partial class ProgressViewModel : BaseViewModel, IAsyncInitialization, IRecipient<AddWeightViewModel>
{
    private readonly IUserContext _userContext;
    public IEnumerable<BodyMeasurementExtended> BodyMeasurements { get; set; }
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
        BodyMeasurements = ConvertToExtendedBodyMeasurements;
        TargetMeasurements = _userContext.TargetMeasurement;
        BodyMeasurement = _userContext.CurrentBodyMeasurement;
        WeightProgress = _userContext.WeightProgress;
        BMI = _userContext.BMI;

        SetupChart();
        WeakReferenceMessenger.Default.Register(this);
    }

    private void UpdateChart()
    {
        SetupChart(); //Throws error now, completly reassign object?
    }

    private void SetupChart()
    {
        try
        {
            var chartEntries = new List<ChartEntry>();

            var bodyMeasurements = _userContext.BodyMeasurements
                .GroupBy(date => date.DateTime.ToString("MM/dd"))
                .Select(x => x.OrderBy(y => y.DateTime).Last())
                .OrderBy(y => y.DateTime)
                .ToList();

            foreach (var bodyMeasurement in bodyMeasurements)
            {
                var chartEntry = new ChartEntry((float)bodyMeasurement.Weight)
                {
                    Color = SKColor.FromHsl(335, 35, 54),
                    ValueLabel = bodyMeasurement.DateTime.ToString("MM/dd")
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
                ValueLabelTextSize = 16,
                LineAreaAlpha = 0,
                PointMode = PointMode.Circle,
                PointSize = 5,
                YAxisMaxTicks = 5,
                LabelOrientation = Orientation.Horizontal,
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

            //LineChart.Entries = new List<ChartEntry>();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void Receive(AddWeightViewModel message)
    {
        UpdateChart();
    }

    private IEnumerable<BodyMeasurementExtended> ConvertToExtendedBodyMeasurements
    {
        get
        {
            var extendedMeasurements = new List<BodyMeasurementExtended>();
            BodyMeasurementExtended previousMeasurement = null;

            foreach (var measurement in _userContext.BodyMeasurements)
            {
                var extendedMeasurement = new BodyMeasurementExtended(measurement);

                if (previousMeasurement != null)
                    previousMeasurement.Difference = Math.Abs(extendedMeasurement.Weight - previousMeasurement.Weight);

                previousMeasurement = extendedMeasurement;
                extendedMeasurements.Add(extendedMeasurement);
            }

            return extendedMeasurements;
        }
    }
}