using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NutritionApp.MVVM.ViewModels;

namespace NutritionApp.MVVM.Views;

public partial class SettingsPage : ContentPage
{
    private readonly List<Expander> expanders = [];

    public SettingsPage(SettingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        expanders.Add(nutritionSettingsExpander);
        expanders.Add(mealTimesExpander);
    }

    private void Expander_ExpandedChanged(object sender, ExpandedChangedEventArgs e)
    {
        CollapseNonSelectedExpander((Expander)sender);
    }

    private void CollapseNonSelectedExpander(Expander selectedExpander)
    {
        expanders.ForEach(x => x.ExpandedChanged -= Expander_ExpandedChanged);

        foreach (var child in expanders)
        {
            if (child is Expander expander && expander != selectedExpander)
                expander.IsExpanded = false;
        }

        expanders.ForEach(x => x.ExpandedChanged += Expander_ExpandedChanged);
    }
}