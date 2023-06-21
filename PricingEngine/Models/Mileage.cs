using PricingEngine.Exceptions;

namespace PricingEngine.Models;

public class Mileage
{
    public int Kilometer { get; }

    private Mileage(int kilometer)
    {
        Kilometer = kilometer;
    }

    public static Mileage OfKilometer(int kilometer)
    {
        if (kilometer < 1)
            throw new InvalidInputException(" should Mileage be at least one kilometer.");

        return new Mileage(kilometer);
    }
}