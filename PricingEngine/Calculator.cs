using System;
using NodaMoney;
using PricingEngine.Exceptions;
using PricingEngine.Models;

namespace PricingEngine;

public static class Calculator
{
    public const int RegularReservationTime = 20;
    public const int MaximumMileage = 250;

    public static Money CalculatePriceOverDuration(this Money pricePerMinute, Duration duration)
    {
        return Price.PerUnit(pricePerMinute).MultiplyWithUnits(duration.Minutes);
    }

    public static Money CalculatePriceOverReservation(this Money pricePerMinute, Duration duration)
    {
        var minutesOverTime = duration.Minutes - RegularReservationTime;
        minutesOverTime = minutesOverTime < 0 ? 0 : minutesOverTime;

        return Price.PerUnit(pricePerMinute).MultiplyWithUnits(minutesOverTime);
    }

    public static Money CalculatePriceOverMileage(this Money pricePerKilometer, Mileage mileage)
    {
        var kilometersOverLimit = mileage.Kilometer - MaximumMileage;
        kilometersOverLimit = kilometersOverLimit < 0 ? 0 : kilometersOverLimit;

        return Price.PerUnit(pricePerKilometer).MultiplyWithUnits(kilometersOverLimit);
    }

    public static Money CalculatePackageOverHours(this int hours)
    {
        try
        {
            return Package.OfHours(hours).Price;
        }
        catch (InvalidInputException)
        {
            return Money.Euro(0);
        }
    }
}