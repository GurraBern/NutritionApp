using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Foods.ValueObjects;

public class Weight : IComparable<Weight>
{
    public double Value { get; private set; }
    public Unit Unit { get; private set; }
    
    private Weight(){}
 
    private Weight(double weight, Unit unit)
    {
        Value = weight;
        Unit = unit;
    }

    public static Result<Weight> Create(double amount, Unit unit)
    {
        if (amount <= 0)
            return Result.Failure<Weight>(FoodErrors.ZeroWeight);

        var weight = new Weight(amount, unit);
        
        return Result.Success(weight);
    }
    
    public static string Abbreviation(Unit unit) => unit switch
    {
        Unit.Grams => "g",
        Unit.Milligram => "mg",
        Unit.Microgram => "μg",
        _ => string.Empty
    };
    
    
    public double ToGrams() => Unit switch
    {
        Unit.Grams => Value,
        Unit.Milligram => Value/1_000,
        Unit.Microgram => Value/1_000_000,
        Unit.Pound => Value * 453.592,
        _ => throw new NotSupportedException($"Unit {Unit} is not supported.")
    };

    public int CompareTo(Weight? other) => ToGrams().CompareTo(other?.ToGrams() ?? 0);
    
    public static bool operator >(Weight left, Weight right) => left.CompareTo(right) > 0;
    public static bool operator <(Weight left, Weight right) => left.CompareTo(right) < 0;
    public static bool operator >=(Weight left, Weight right) => left.CompareTo(right) >= 0;
    public static bool operator <=(Weight left, Weight right) => left.CompareTo(right) <= 0;
    public static bool operator ==(Weight left, Weight right) => left.CompareTo(right) == 0;

    public static bool operator !=(Weight left, Weight right) => !(left == right);
}

public enum Unit
{
   Serving,
   Grams,
   Milligram,
   Microgram,
   Pound,
   Ounce
}

public enum MeasurementSystem
{
    Metric = 1,
    Imperial = 2
}
