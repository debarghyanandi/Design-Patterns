using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.SimpleFactory;

// Simple Factory: one place decides which IPayment class to create, from an input value.
// Cost: a new payment type means editing this switch (breaks Open/Closed).
public static class PaymentFactory
{
    public static IPayment Create(string type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type);          // null, "" or "  " fail early, with the parameter name

        return type.Trim().ToLowerInvariant() switch              // Invariant: same result on every machine's culture
        {
            "card"   => new CardPayment(),
            "upi"    => new UpiPayment(),
            "wallet" => new WalletPayment(),
            _ => throw new ArgumentException($"Unknown payment type: '{type}'.", nameof(type))
        };
    }
}
