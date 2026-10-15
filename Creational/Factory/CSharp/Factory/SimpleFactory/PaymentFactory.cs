using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.SimpleFactory;

// SIMPLE FACTORY (a common idiom, NOT one of the 23 GoF patterns)
//
// Why:  the client should not decide which concrete class to `new`. One place does it.
// Flow: Checkout.Pay("upi") -> PaymentFactory.Create("upi") -> switch -> new UpiPayment()
//       -> returned as IPayment -> Checkout calls Pay().
// Cost: a new payment type means EDITING this switch (breaks Open/Closed).
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
            _ => throw new ArgumentException($"Unknown payment type: '{type}'.", nameof(type))   // fail loudly, no default
        };
    }
}
