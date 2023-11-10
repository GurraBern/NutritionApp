using CommunityToolkit.Mvvm.Input;

namespace NutritionApp.MVVM.Models;

public class OptionItem
{
    public string Text { get; }
    public IAsyncRelayCommand Command { get; }

    public OptionItem(string text, IAsyncRelayCommand command)
    {
        Text = text;
        Command = command;
    }
}
