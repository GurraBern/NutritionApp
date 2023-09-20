using CommunityToolkit.Mvvm.ComponentModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    public bool isBusy;

    [ObservableProperty]
    public bool noResult;

    [ObservableProperty]
    public string _title;
}
