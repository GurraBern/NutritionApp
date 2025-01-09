using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Shared;

public class NutrientWrapper(NutrientDto trackedNutrient)
{
    private const double MaxProgress = 100;
    private NutrientDto TrackedNutrient { get; } = trackedNutrient;

    //TODO what happens if new() maybe rethink?
    private NutrientDto NutritionTarget { get; set; } = new();

    public string Name => TrackedNutrient.Name;
    public UnitDto Unit => TrackedNutrient.Unit;
    public double Weight => TrackedNutrient.Weight;
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

    private static double ConvertUnit(NutrientDto nutrient) => nutrient.Unit switch
    {
        UnitDto.Grams => nutrient.Weight,
        UnitDto.Milligram => nutrient.Weight * 1_000, 
        UnitDto.Microgram => nutrient.Weight * 1000_000,
        _ => -1
    };
}