using FluentAssertions;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Tests.Core.Food;

public class WeightTests
{
	public static TheoryData<WeightUnit, double, double> ToGramsTestData => new()
	{
		{ WeightUnit.Grams, 1000, 1000 },
		{ WeightUnit.Milligram, 1000, 1 },
		{ WeightUnit.Microgram, 1000000, 1 },
		{ WeightUnit.Pound, 1, 453.592d }
	};
	
	[Theory]
	[MemberData(nameof(ToGramsTestData), MemberType = typeof(WeightTests))]	
	public void ToGrams_ShouldConvertCorrectly(WeightUnit unit, double amount, double expected)
	{
		// Arrange
		var weight = Weight.Create(amount, unit).Value;

		// Act
		var result = weight.ToGrams();

		// Assert
		result.Should().Be(expected);
	}
	
	public static TheoryData<WeightUnit, double> EqualAmountTestData => new()
	{
		{ WeightUnit.Milligram, 250_000 },
		{ WeightUnit.Microgram, 250_000_000 },
	};
	
	[Theory]
	[MemberData(nameof(EqualAmountTestData), MemberType = typeof(WeightTests))]
	public void Given_equal_amount_Then_return_true(WeightUnit unit, double amount)
	{
		// Arrange
		var weight1 = Weight.Create(250, WeightUnit.Grams).Value;
		var weight2 = Weight.Create(amount, unit).Value;
	
		// Act
		var result = weight1 == weight2;
	
		// Assert
		result.Should().BeTrue();
	}
	
	[Fact]
	public void OperatorGreaterThan_ShouldReturnTrue_WhenFirstWeightIsGreater()
	{
		// Arrange
		var weight1 = Weight.Create(2000, WeightUnit.Grams).Value;
		var weight2 = Weight.Create(1000, WeightUnit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeGreaterThan(weight2);
	}
	
	[Fact]
	public void OperatorLessThan_ShouldReturnTrue_WhenFirstWeightIsLesser()
	{
		// Arrange
		var weight1 = Weight.Create(500, WeightUnit.Grams).Value;
		var weight2 = Weight.Create(1000, WeightUnit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeLessThan(weight2);
	}
	
	[Fact]
	public void OperatorGreaterThanOrEqual_ShouldReturnTrue_WhenFirstWeightIsGreaterOrEqual()
	{
		// Arrange
		var weight1 = Weight.Create(1000, WeightUnit.Grams).Value;
		var weight2 = Weight.Create(1000, WeightUnit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeGreaterThanOrEqualTo(weight2);
	}
	
	[Fact]
	public void OperatorLessThanOrEqual_ShouldReturnTrue_WhenFirstWeightIsLesserOrEqual()
	{
		// Arrange
		var weight1 = Weight.Create(1000, WeightUnit.Grams).Value;
		var weight2 = Weight.Create(1000, WeightUnit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeLessThanOrEqualTo(weight2);
	}
}