using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NodaMoney;
using PricingEngine.Exceptions;
using PricingEngine.Models;
using Xunit;

namespace PricingEngine.Tests;

[ExcludeFromCodeCoverage]
public static class PriceTests
{
    #region PerUnit

    [Theory]
    [InlineData(0.01)]
    public static void PerUnit_With_positive_unit_price(decimal unitPrice)
    {
        // Arrange
        var pricePerUnit = Money.Euro(unitPrice);

        // Act
        var action = () => Price.PerUnit(pricePerUnit);

        // Assert
        action.Should().NotThrow();
    }

    [Fact]
    public static void PerUnit_With_zero_unit_price()
    {
        // Arrange
        var pricePerUnit = Money.Euro(0);
        
        // Act
        var action = () => Price.PerUnit(pricePerUnit);
        
        // Assert
        action.Should().Throw<InvalidInputException>();
    }

    [Fact]
    public static void PerUnit_With_negative_unit_price()
    {
        // Arrange
        var pricePerUnit = Money.Euro(-0.01);
        
        // Act
        var action = () => Price.PerUnit(pricePerUnit);
        
        // Assert
        action.Should().Throw<InvalidInputException>();
    }

    #endregion

    #region MultiplyWithUnits

    [Theory]
    [InlineData(1, 0.01)]
    public static void MultiplyWithUnits_With_units(int units, decimal unitPrice)
    {
        // Arrange
        var pricePerUnit = Money.Euro(unitPrice);
        var expected = units * pricePerUnit;

        // Act
        var result = Price.PerUnit(pricePerUnit).MultiplyWithUnits(units);

        // Assert
        result.Should().Be(expected);
    }

    #endregion
}