using FluentAssertions;
using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Tests.Core.Food;

public class WeightTests
{
	[Theory]
	[InlineData(Unit.Grams, 1000, 1000)]
	[InlineData(Unit.Milligram, 1000, 1)]
	[InlineData(Unit.Microgram, 1000_000, 1)]
	[InlineData(Unit.Pound, 1, 453.592)]
	public void ToGrams_ShouldConvertCorrectly(Unit unit, double amount, double expected)
	{
		// Arrange
		var weight = Weight.Create(amount, unit).Value;

		// Act
		var result = weight.ToGrams();

		// Assert
		result.Should().Be(expected);
	}
	
	[Theory]
	[InlineData(Unit.Milligram, 250_000)]
	[InlineData(Unit.Microgram, 250_000_000)]
	public void Given_equal_amount_Then_return_true(Unit unit, double amount)
	{
		// Arrange
		var weight1 = Weight.Create(250, Unit.Grams).Value;
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
		var weight1 = Weight.Create(2000, Unit.Grams).Value;
		var weight2 = Weight.Create(1000, Unit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeGreaterThan(weight2);
	}
	
	[Fact]
	public void OperatorLessThan_ShouldReturnTrue_WhenFirstWeightIsLesser()
	{
		// Arrange
		var weight1 = Weight.Create(500, Unit.Grams).Value;
		var weight2 = Weight.Create(1000, Unit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeLessThan(weight2);
	}
	
	[Fact]
	public void OperatorGreaterThanOrEqual_ShouldReturnTrue_WhenFirstWeightIsGreaterOrEqual()
	{
		// Arrange
		var weight1 = Weight.Create(1000, Unit.Grams).Value;
		var weight2 = Weight.Create(1000, Unit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeGreaterThanOrEqualTo(weight2);
	}
	
	[Fact]
	public void OperatorLessThanOrEqual_ShouldReturnTrue_WhenFirstWeightIsLesserOrEqual()
	{
		// Arrange
		var weight1 = Weight.Create(1000, Unit.Grams).Value;
		var weight2 = Weight.Create(1000, Unit.Grams).Value;
	
		// Act & Assert
		weight1.Should().BeLessThanOrEqualTo(weight2);
	}
}