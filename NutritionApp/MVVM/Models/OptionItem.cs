using CommunityToolkit.Mvvm.Input;

namespace NutritionApp.MVVM.Models;

public class OptionItem(string text, IRelayCommand command)
{
    public string Text { get; } = text;
    public IRelayCommand Command { get; } = command;
}