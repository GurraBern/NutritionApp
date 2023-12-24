using CommunityToolkit.Mvvm.Input;

namespace NutritionApp.MVVM.Models;

public class OptionItem(string text, IAsyncRelayCommand command)
{
    public string Text { get; } = text;
    public IAsyncRelayCommand Command { get; } = command;
}
