using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using PricingEngine.Exceptions;
using PricingEngine.Models;
using Xunit;

namespace PricingEngine.Tests;

[ExcludeFromCodeCoverage]
public static class MileageTests
{
    #region OfKilometer

    [Theory]
    [InlineData(1)]
    public static void OfKilometer_With_positive_kilometers(int kilometers)
    {
        // Arrange
        // Act
        var action = () => Mileage.OfKilometer(kilometers);

        // Assert
        action.Should().NotThrow();
        action.Invoke().Kilometer.Should().Be(kilometers);
    }

    [Fact]
    public static void OfKilometer_With_zero_kilometers()
    {
        // Arrange
        // Act
        var action = () => Mileage.OfKilometer(0);
        
        // Assert
        action.Should().Throw<InvalidInputException>();
    }
    
    [Fact]
    public static void OfKilometer_With_negative_kilometers()
    {
        // Arrange
        // Act
        var action = () => Mileage.OfKilometer(-1);

        // Assert
        action.Should().Throw<InvalidInputException>();
    }

    #endregion
}