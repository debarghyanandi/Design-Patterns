using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.SimpleFactory;

// The client. It knows only IPayment and the factory, never a concrete class.
public sealed class Checkout
{
    public void Pay(string type, decimal amount)
    {
        IPayment payment = PaymentFactory.Create(type);           // a local: each call gets its own object
        payment.Pay(amount);
    }
}
