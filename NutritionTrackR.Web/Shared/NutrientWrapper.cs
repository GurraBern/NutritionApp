using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Shared;

public class NutrientWrapper(NutrientDto trackedNutrient)
{
    private const double MaxProgress = 100;
    private NutrientDto TrackedNutrient { get; } = trackedNutrient;

    //TODO what happens if new() maybe rethink?
    private NutrientDto NutritionTarget { get; set; } = new();

    public string Name => TrackedNutrient.Name;
    public string Unit => TrackedNutrient.Unit;
    public double Weight => Math.Round(TrackedNutrient.Weight, 2);
    public bool IsComplete => GetProgress() > MaxProgress;

    public void AddWeight(NutrientWrapper nutrient)
    {
        TrackedNutrient.Weight += nutrient.Weight; //TODO need to handle addition with the use of Unit
    }

    public void SetNutrientTarget(NutrientDto nutrientTarget)
    {
        NutritionTarget = nutrientTarget;
    }
    public double GetProgress()
    {
        if (NutritionTarget.Weight == 0)
            return MaxProgress;
    
        return Math.Round(TrackedNutrient.Weight/NutritionTarget.Weight, 2) * MaxProgress;
    }

    public void ClearWeight()
    {
        TrackedNutrient.Weight = 0;
    }

    public string ToProgressDisplayString() => Math.Round(TrackedNutrient.Weight, 2) + "/" + NutritionTarget.Weight + " " + NutritionTarget.Unit;
}