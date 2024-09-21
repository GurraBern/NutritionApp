using FluentResults;

namespace NutritionTrackR.Core.Food.ValueObjects;

public class Weight
{
    public decimal Value { get; }
    public MeasurementSystem MeasurementSystem { get; }
 
    private Weight(decimal weight, MeasurementSystem measurementSystem)
    {
        Value = weight;
        MeasurementSystem = measurementSystem;
    }

    public static Result<Weight> Create(decimal amount, MeasurementSystem measurementSystem)
    {
        if (amount < 0)
            Result.Fail("Weight cannot be negative");

        var weight = new Weight(amount, measurementSystem);
        
        return Result.Ok(weight);
    }
    
    //TODO Add method for comparing with both metric and imperial system
}

public enum MeasurementSystem
{
    Metric = 1,
    Imperial = 2
}


