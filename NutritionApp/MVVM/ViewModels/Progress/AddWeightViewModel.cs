using CommunityToolkit.Mvvm.Input;
using NutritionApp.Data.Services;

namespace NutritionApp.MVVM.ViewModels;

public partial class AddWeightViewModel(IMeasurementsService measurementsService)
{
    private readonly IMeasurementsService _measurementsService = measurementsService;

    [RelayCommand]
    private async Task AddNewWeight(double weight)
    {
        await _measurementsService.AddNewWeight(weight);
    }
}