using CommunityToolkit.Mvvm.Input;
using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public partial class AddWeightViewModel(IUserDetailService userDetailService)
{
    private readonly IUserDetailService userDetailService = userDetailService;

    [RelayCommand]
    private async Task AddNewWeight(double weight)
    {
        await userDetailService.AddNewWeight(weight);
    }
}