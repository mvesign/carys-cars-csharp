using NodaMoney;
using PricingEngine.Models;

namespace PricingEngine;

public static class Calculator
{
    public const int RegularReservationTime = 20;

    public static Money CalculatePriceOverDuration(this Money pricePerMinute, Duration duration)
    {
        return Price.PerUnit(pricePerMinute).MultiplyPerUnits(duration.Minutes);
    }

    public static Money CalculatePriceOverReservation(this Money pricePerMinute, Duration duration)
    {
        var minutesOverTime = duration.Minutes - RegularReservationTime;
        minutesOverTime = minutesOverTime < 0 ? 0 : minutesOverTime;

        return Price.PerUnit(pricePerMinute).MultiplyPerUnits(minutesOverTime);
    }
}