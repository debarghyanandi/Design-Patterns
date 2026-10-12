using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.FactoryMethod;

// Factory Method: the base class owns the workflow; each subclass decides which IPayment to create.
// A new payment type = a new subclass. No existing code changes (Open/Closed).
public abstract class PaymentProcessor
{
    protected abstract IPayment CreatePayment();                  // the factory method

    public void ProcessPayment(decimal amount)                    // shared workflow, written once
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount); // a rule every payment type gets for free
        IPayment payment = CreatePayment();
        payment.Pay(amount);
    }
}

public sealed class CardProcessor : PaymentProcessor
{
    protected override IPayment CreatePayment() => new CardPayment();
}

public sealed class UpiProcessor : PaymentProcessor
{
    protected override IPayment CreatePayment() => new UpiPayment();
}

public sealed class WalletProcessor : PaymentProcessor
{
    protected override IPayment CreatePayment() => new WalletPayment();
}
