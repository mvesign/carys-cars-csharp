using System;
using System.Diagnostics.CodeAnalysis;

namespace PricingEngine.Exceptions;

[ExcludeFromCodeCoverage]
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}