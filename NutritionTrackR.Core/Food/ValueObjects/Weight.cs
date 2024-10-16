﻿using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Food.ValueObjects;

public class Weight
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
