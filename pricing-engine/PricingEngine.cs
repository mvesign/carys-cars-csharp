using NodaMoney;

namespace pricing_engine;

public interface PricingEngine
{
    Money CalculatePrice(Duration duration, Money pricePerMinute);
}
