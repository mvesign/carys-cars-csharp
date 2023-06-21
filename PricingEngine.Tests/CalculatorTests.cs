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

    #region CalculatePriceOverMileage

    [Theory]
    [InlineData(251, 0.19)]
    [InlineData(300, 0.19)]
    public static void CalculatePriceOverMileage_With_over_limit_mileage(
        int kilometers, decimal unitPrice
    )
    {
        // Arrange
        var mileage = Mileage.OfKilometer(kilometers);
        var pricePerKilometer = Money.Euro(unitPrice);
        var expected = pricePerKilometer * (mileage.Kilometer - Calculator.MaximumMileage);

        // Act
        var actual = pricePerKilometer.CalculatePriceOverMileage(mileage);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(0.19)]
    public static void CalculatePriceOverMileage_With_zero_over_limit_mileage(decimal unitPrice)
    {
        // Arrange
        var mileage = Mileage.OfKilometer(Calculator.MaximumMileage);
        var pricePerKilometer = Money.Euro(unitPrice);
        var expected = Money.Euro(0);

        // Act
        var actual = pricePerKilometer.CalculatePriceOverMileage(mileage);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(100, 0.19)]
    [InlineData(200, 0.19)]
    public static void CalculatePriceOverMileage_With_negative_over_limit_mileage(
        int kilometers, decimal unitPrice
    )
    {
        // Arrange
        var mileage = Mileage.OfKilometer(kilometers);
        var pricePerKilometer = Money.Euro(unitPrice);
        var expected = Money.Euro(0);

        // Act
        var actual = pricePerKilometer.CalculatePriceOverMileage(mileage);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    #endregion

    #region CalculatePackageOverHours

    [Theory]
    [InlineData(3, 19)]
    [InlineData(6, 39)]
    [InlineData(24, 59)]
    [InlineData(72, 95)]
    [InlineData(168, 209)]
    public static void CalculatePackageOverHours_With_supported_hours(int hours, decimal expected)
    {
        // Arrange
        var expectedPrice = Money.Euro(expected);

        // Act
        var actual = hours.CalculatePackageOverHours();
    
        // Assert
        actual.Should().BeEquivalentTo(expectedPrice);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(7)]
    [InlineData(25)]
    public static void CalculatePackageOverHours_With_unsupported_hours(int hours)
    {
        // Arrange
        var expected = Money.Euro(0);

        // Act
        var actual = hours.CalculatePackageOverHours();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    #endregion
}