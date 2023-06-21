using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using PricingEngine.Exceptions;
using PricingEngine.Models;
using Xunit;

namespace PricingEngine.Tests;

[ExcludeFromCodeCoverage]
public static class DurationTest
{
    #region OfMinutes

    [Theory]
    [InlineData(1)]
    public static void OfMinutes_With_positive_minutes(int minutes)
    {
        // Arrange
        // Act
        var action = () => Duration.OfMinutes(minutes);

        // Assert
        action.Should().NotThrow();
        action.Invoke().Minutes.Should().Be(minutes);
    }

    [Fact]
    public static void OfMinutes_With_zero_minutes()
    {
        // Arrange
        // Act
        var action = () => Duration.OfMinutes(0);
        
        // Assert
        action.Should().Throw<InvalidInputException>();
    }
    
    [Fact]
    public static void OfMinutes_With_negative_minutes()
    {
        // Arrange
        // Act
        var action = () => Duration.OfMinutes(-1);

        // Assert
        action.Should().Throw<InvalidInputException>();
    }

    #endregion
}