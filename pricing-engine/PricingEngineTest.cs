using NodaMoney;

namespace pricing_engine;

public class PricingEngineTest
{
    [Fact]
    public void calculatePrice_charged_per_minute()
    {
        var pricingEngine = new PricingEngine();

        var duration = Duration.ofMinutes(1);
        var pricePerMinute = Money.Euro(0.30);
        var actual = pricingEngine.calculatePrice(duration, pricePerMinute);

        var expected = pricePerMinute;
        Assert.Equal(expected, actual);
    }
}

public class PricingEngine
{
    public Money calculatePrice(Duration duration, Money pricePerMinute)
    {
        return Int32.Parse(duration.ToString()) * pricePerMinute;
    }
}