using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using NutritionApp.Data.Context.Interfaces;
using NutritionApp.MVVM.Views;

namespace NutritionApp.MVVM.ViewModels;

public partial class AddWeightViewModel
{
    private readonly IUserContext _userContext;

    public AddWeightViewModel(IUserContext userContext)
    {
        this._userContext = userContext;
    }

    [RelayCommand]
    private async Task AddNewWeight(double weight)
    {
        await _userContext.AddNewWeight(weight);
        await Shell.Current.GoToAsync($"//{nameof(ProgressPage)}");
        WeakReferenceMessenger.Default.Send(this, "AddedNewWeight");
    }
}