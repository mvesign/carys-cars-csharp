using NodaMoney;
using PricingEngine.Models;

namespace PricingEngine;

public static class Calculator
{
    public static Money CalculatePrice(Duration duration, Money pricePerMinute)
    {
        return Price.PerUnit(pricePerMinute).MultiplyPerUnits(duration.Minutes);
    }
}