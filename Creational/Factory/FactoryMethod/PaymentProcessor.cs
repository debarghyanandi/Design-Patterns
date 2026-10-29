using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.FactoryMethod;

// FACTORY METHOD (GoF)
//
// Why:  the workflow (validate, then pay) is the same for every payment type.
//       Only "which IPayment to create" differs. So the base class writes the workflow once
//       and leaves ONE method - the factory method - for each subclass to fill in.
// Flow: processor.ProcessPayment(100)
//       -> base class checks the amount
//       -> base class calls CreatePayment()
//       -> the SUBCLASS's override runs and returns, e.g., a UpiPayment
//       -> base class calls Pay() on it.
// Gain: a new payment type = a new subclass. No existing code is edited (Open/Closed).
// How:  INHERITANCE - the subclass decides.
public abstract class PaymentProcessor
{
    protected abstract IPayment CreatePayment();                  // the factory method; protected: only the workflow calls it

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
