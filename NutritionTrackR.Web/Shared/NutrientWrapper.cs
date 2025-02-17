using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Shared;

//TODO no reason to take in dto we just need to map
public class NutrientWrapper(NutrientDto trackedNutrient)
{
    private const double MaxProgress = 100;
    public NutrientDto TrackedNutrient { get; } = trackedNutrient;

    //TODO what happens if new() maybe rethink?
    private NutrientDto NutritionTarget { get; set; } = new();

    public string Name => TrackedNutrient.Name;
    public string Unit => TrackedNutrient.Unit;
    
    public double Weight
    {
        get => Math.Round(TrackedNutrient.Weight, 2);
        set => trackedNutrient.Weight = value;
    }
    
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

    public string ToProgressDisplayString()
    {
        if (TrackedNutrient.Weight == 0)
            return "-";

        return NutritionTarget.Weight == 0
            ? $"{Math.Round(TrackedNutrient.Weight, 2)} {TrackedNutrient.Unit}"
            : $"{Math.Round(TrackedNutrient.Weight, 2)} / {NutritionTarget.Weight} {TrackedNutrient.Unit}";
    }    
}