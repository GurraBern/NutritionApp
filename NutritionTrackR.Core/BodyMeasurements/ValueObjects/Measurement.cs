using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.WeightTracking.ValueObjects;

public class Measurement
{
    public decimal Length { get; private set; }

    public MeasurementUnit Unit { get; private set; }
    

    private Measurement(){}
        
    public static Result<Measurement> Create(decimal length, MeasurementUnit measurementUnit)
    {
        if (length < 0)
        {
            return Result.Failure<Measurement>("Length cannot be negative");
        }

        return Result.Success(new Measurement
        {
            Length = length,
            Unit = measurementUnit
        });
    }
}

public class MeasurementUnit
{
    public string Name { get; private set; }
    public MeasurementUnitEnum Unit { get; private set; }
    
    public static MeasurementUnit Meter => new("Meter", MeasurementUnitEnum.Meter);
    public static MeasurementUnit Decimeter => new("Decimeter", MeasurementUnitEnum.Decimeter);
    public static MeasurementUnit Centimeter => new("Centimeter", MeasurementUnitEnum.Centimeter);
    public static MeasurementUnit Millimeter => new("Millimeter", MeasurementUnitEnum.Millimeter);
    
    public MeasurementUnit(string name, MeasurementUnitEnum unit)
    {
        Name = name;
        Unit = unit;
    }

    public static MeasurementUnit FromString(string unit) => unit switch
    {
        "Meter" => Meter,
        "Decimeter" => Decimeter,
        "Centimeter" => Centimeter,
        "Millimeter" => Millimeter,
        _ => throw new ArgumentException(nameof(unit)), //TODO result pattern
    };
}

public enum MeasurementUnitEnum
{
    Meter,
    Decimeter,
    Centimeter,
    Millimeter,
}