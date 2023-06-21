using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NodaMoney;
using PricingEngine.Models;
using Xunit;

namespace PricingEngine.Tests;

[ExcludeFromCodeCoverage]
public static class PricingEngineTest
{
    #region CalculatePriceOverDuration

    [Theory]
    [InlineData(1, 0.24)]
    [InlineData(10, 0.24)]
    [InlineData(100, 0.24)]
    public static void CalculatePriceOverDuration_With_being_charged_per_minute(int minutes, decimal unitPrice)
    {
        // Arrange
        var duration = Duration.OfMinutes(minutes);
        var pricePerMinute = Money.Euro(unitPrice);
        var expected = pricePerMinute * minutes;
        
        // Act
        var actual = pricePerMinute.CalculatePriceOverDuration(duration);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    #endregion

    #region CalculatePriceOverReservation

    [Theory]
    [InlineData(21, 0.09)]
    [InlineData(100, 0.09)]
    public static void CalculatePriceOverReservation_With_extra_reservation_time(
        int minutes, decimal unitPrice
    )
    {
        // Arrange
        var duration = Duration.OfMinutes(minutes);
        var pricePerMinute = Money.Euro(unitPrice);
        var expected = pricePerMinute * (duration.Minutes - Calculator.RegularReservationTime);

        // Act
        var actual = pricePerMinute.CalculatePriceOverReservation(duration);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(0.09)]
    public static void CalculatePriceOverReservation_With_zero_extra_reservation_time(decimal unitPrice)
    {
        // Arrange
        var duration = Duration.OfMinutes(Calculator.RegularReservationTime);
        var pricePerMinute = Money.Euro(unitPrice);
        var expected = Money.Euro(0);

        // Act
        var actual = pricePerMinute.CalculatePriceOverReservation(duration);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(1, 0.09)]
    [InlineData(10, 0.09)]
    [InlineData(19, 0.09)]
    public static void CalculatePriceOverReservation_With_negative_extra_reservation_time(
        int minutes, decimal unitPrice
    )
    {
        // Arrange
        var duration = Duration.OfMinutes(minutes);
        var pricePerMinute = Money.Euro(unitPrice);
        var expected = Money.Euro(0);

        // Act
        var actual = pricePerMinute.CalculatePriceOverReservation(duration);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    #endregion
}