using NodaMoney;
using PricingEngine.Exceptions;

namespace PricingEngine.Models;

public class Price
{
    private readonly Money _pricePerUnit;

    private Price(Money pricePerUnit)
    {
        _pricePerUnit = pricePerUnit;
    }

    public static Price PerUnit(Money pricePerUnit)
    {
        if (pricePerUnit <= 0)
            throw new InvalidInputException("Price per unit must be greater than 0.");

        return new Price(pricePerUnit);
    }

    public Money MultiplyPerUnits(int units) =>
        _pricePerUnit * units;
}