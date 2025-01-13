using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Shared.ValueObjects;

public class Weight : IComparable<Weight>
{
    public double Value { get; private set; }
    public WeightUnit Unit { get; private set; }
    
    private Weight(){}
 
    private Weight(double weight, WeightUnit unit)
    {
        Value = weight;
        Unit = unit;
    }

    public static Result<Weight> Create(double amount, WeightUnit unit)
    {
        if (amount <= 0)
            return Result.Failure<Weight>(FoodErrors.ZeroWeight);

        var weight = new Weight(amount, unit);
        
        return Result.Success(weight);
    }
    
    public static string Abbreviation(WeightUnit weightUnit) => weightUnit.Unit switch
    {
        WeightUnitEnum.Grams => "g",
        WeightUnitEnum.Milligram => "mg",
        WeightUnitEnum.Microgram => "μg",
        _ => string.Empty
    };
    
    //TODO return result instead
    public double ToGrams() => Unit.Unit switch
    {
        WeightUnitEnum.Grams => Value,
        WeightUnitEnum.Milligram => Value/1_000,
        WeightUnitEnum.Microgram => Value/1_000_000,
        WeightUnitEnum.Pound => Value * 453.592,
        _ => throw new NotSupportedException($"Unit {Unit} is not supported.")
    };

    public int CompareTo(Weight? other) => ToGrams().CompareTo(other?.ToGrams() ?? 0);
    
    public static bool operator >(Weight left, Weight right) => left.CompareTo(right) > 0;
    public static bool operator <(Weight left, Weight right) => left.CompareTo(right) < 0;
    public static bool operator >=(Weight left, Weight right) => left.CompareTo(right) >= 0;
    public static bool operator <=(Weight left, Weight right) => left.CompareTo(right) <= 0;
    public static bool operator ==(Weight left, Weight right) => left.CompareTo(right) == 0;
    public static bool operator !=(Weight left, Weight right) => !(left == right);


    private bool Equals(Weight other) => Value.Equals(other.Value) && Unit == other.Unit;
    override public bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;

        return Equals((Weight)obj);
    }
    override public int GetHashCode() => HashCode.Combine(Value, (int)Unit.Unit);
}

public class WeightUnit
{
    public string Name { get; private set; }
    public WeightUnitEnum Unit { get; private set; }
    
    public static WeightUnit Serving => new("Serving", WeightUnitEnum.Serving);
    public static WeightUnit Grams => new("Grams", WeightUnitEnum.Grams);
    public static WeightUnit Milligram => new("Milligram", WeightUnitEnum.Milligram);
    public static WeightUnit Microgram => new("Microgram", WeightUnitEnum.Microgram);
    public static WeightUnit Pound => new("Pound", WeightUnitEnum.Pound);
    public static WeightUnit Ounce => new("Ounce", WeightUnitEnum.Ounce);
    public static WeightUnit Kcal => new("Kcal", WeightUnitEnum.Kcal);
    
    public WeightUnit(string name, WeightUnitEnum unit)
    {
        Name = name;
        Unit = unit;
    }

    public static Result<WeightUnit> FromString(string unit) => unit switch
    {
        "Serving" => Result.Success(Serving),
        "Grams" => Result.Success(Grams),
        "Milligram" => Result.Success(Milligram),
        "Microgram" => Result.Success(Microgram),
        "Pound" => Result.Success(Pound),
        "Ounce" => Result.Success(Ounce),
        "Kcal" => Result.Success(Kcal),
        _ => Result.Failure<WeightUnit>("Unit is not supported.")
    };
}

public enum WeightUnitEnum
{
   Serving,
   Grams,
   Milligram,
   Microgram,
   Pound,
   Ounce,
   Kcal
}

public enum MeasurementSystem
{
    Metric = 1,
    Imperial = 2
}

