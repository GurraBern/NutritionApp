using FluentResults;

namespace NutritionTrackR.Core.Food.ValueObjects;

public class Weight
{
    public decimal Value { get; private set; }
    public Unit Unit { get; private set; }
    
    private Weight(){}
 
    private Weight(decimal weight, Unit unit)
    {
        Value = weight;
        Unit = unit;
    }

    public static Result<Weight> Create(decimal amount, Unit unit)
    {
        if (amount <= 0)
            return Result.Fail("Weight must be greater than zero");

        var weight = new Weight(amount, unit);
        
        return Result.Ok(weight);
    }
    
    public static string Abbreviation(Unit unit) => unit switch
    {
        Unit.Grams => "g",
        Unit.Milligram => "mg",
        Unit.Microgram => "μg",
        _ => string.Empty
    };
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
