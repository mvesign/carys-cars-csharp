using NodaMoney;

namespace pricing_engine;

public class PricingEngine
{
    public Money CalculatePrice(Duration duration, Money pricePerMinute)
    {
        return Int32.Parse(duration.ToString()) * pricePerMinute;
    }
}