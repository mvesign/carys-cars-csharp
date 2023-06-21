using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using PricingEngine.Exceptions;
using PricingEngine.Models;
using Xunit;

namespace PricingEngine.Tests;

[ExcludeFromCodeCoverage]
public static class PackageTests
{
    #region OfHours

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(24)]
    [InlineData(72)]
    [InlineData(168)]
    public static void OfHours_With_supported_hours(int hours)
    {
        // Arrange
        var minutes = hours * 60;
        var kilometers = hours switch
        {
            3 => 75,
            6 => 125,
            24 => 200,
            72 => 450,
            168 => 700
        };
        var price = hours switch
        {
            3 => 19,
            6 => 39,
            24 => 59,
            72 => 95,
            168 => 209
        };

        // Act
        var result = Package.OfHours(hours);

        // Assert
        result.Duration.Minutes.Should().Be(minutes);
        result.Mileage.Kilometer.Should().Be(kilometers);
        result.Price.Amount.Should().Be(price);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(7)]
    [InlineData(25)]
    public static void OfHours_With_unsupported_hours(int hours)
    {
        // Arrange
        // Act
        var action = () => Package.OfHours(hours);

        // Assert
        action.Should().Throw<InvalidInputException>();
    }

    #endregion
}