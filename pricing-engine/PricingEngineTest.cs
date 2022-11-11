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

public class Duration
{
    private int minutes;

    private Duration(int minutes)
    {
        this.minutes = minutes;
    }

    public static Duration ofMinutes(int minutes)
    {
        if (minutes < 1)
        {
            throw new SorryInvalidDurationProvided("Sorry, Duration should be at least one minute.");
        }
        
        return new Duration(minutes);
    }

    public static Duration FromString(string durationAsText)
    {
        return new Duration(Int32.Parse(durationAsText));
    }

    public override string ToString()
    {
        return this.minutes.ToString();
    }

    public override bool Equals(object? compareTo)
    {
        if (this.GetType().Equals(compareTo.GetType()))
        {
            Duration other = (Duration) compareTo;
            
            return this.minutes == other.minutes;
        }

        return false;
    }
}

public class PricingEngine
{
    public Money calculatePrice(Duration duration, Money pricePerMinute)
    {
        throw new NotImplementedException();
    }
}