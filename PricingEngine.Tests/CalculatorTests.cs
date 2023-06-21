using System.Diagnostics.CodeAnalysis;
using NodaMoney;
using PricingEngine.Models;
using Xunit;

namespace PricingEngine.Tests;

[ExcludeFromCodeCoverage]
public static class PricingEngineTest
{
    #region CalculatePrice

    [Theory]
    [InlineData(1, 0.24)]
    public static void CalculatePrice_With_being_charged_per_minute(int minute, decimal pricePerMinute)
    {
        // Arrange
        var duration = Duration.OfMinutes(minute);
        var expected = Money.Euro(pricePerMinute);
        
        // Act
        var actual = Calculator.CalculatePrice(duration, expected);

        // Assert
        Assert.Equal(expected, actual);
    }

    #endregion
}