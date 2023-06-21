using PricingEngine.Exceptions;

namespace PricingEngine.Models;

public class Duration
{
    public int Minutes { get; }

    private Duration(int minutes)
    {
        Minutes = minutes;
    }

    public static Duration OfMinutes(int minutes)
    {
        if (minutes < 1)
            throw new InvalidInputException("Duration should be at least one minute.");

        return new Duration(minutes);
    }
}
