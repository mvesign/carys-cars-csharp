using NodaMoney;

namespace pricing_engine;

public class PricingEngineMvp : PricingEngine
{
    public Money CalculatePrice(Duration duration, Money pricePerMinute)
    {
        return duration.MultiplyByPricePerMinute(pricePerMinute);
    }
}