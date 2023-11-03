namespace NutritionApp.MVVM.Models;

public class SelectionCollection
{
    public List<OptionItem> Options { get; set; } = new();
    public bool CanExecuteCommand = true;

    public SelectionCollection()
    {

    }
}
