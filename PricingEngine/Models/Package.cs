using NodaMoney;
using PricingEngine.Exceptions;

namespace PricingEngine.Models;

public class Package
{
    public Duration Duration { get; }
    public Mileage Mileage { get; }
    public Money Price { get; }

    private Package(Duration duration, Mileage mileage, Money price)
    {
        Duration = duration;
        Mileage = mileage;
        Price = price;
    }

    public static Package OfHours(int hours)
    {
        var duration = Duration.OfMinutes(hours * 60);
        return hours switch
        {
            3 => new Package(duration, Mileage.OfKilometer(75), Money.Euro(19)),
            6 => new Package(duration, Mileage.OfKilometer(125), Money.Euro(39)),
            24 => new Package(duration, Mileage.OfKilometer(200), Money.Euro(59)),
            72 => new Package(duration, Mileage.OfKilometer(450), Money.Euro(95)),
            168 => new Package(duration, Mileage.OfKilometer(700), Money.Euro(209)),
            _ => throw new InvalidInputException($"Hours of '{hours}' is not supported.")
        };
    }
}