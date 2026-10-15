using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.SimpleFactory;

// The CLIENT of the Simple Factory.
// It knows only IPayment and PaymentFactory - never CardPayment, UpiPayment or WalletPayment.
public sealed class Checkout
{
    public void Pay(string type, decimal amount)
    {
        IPayment payment = PaymentFactory.Create(type);           // a local: each call gets its own object
        payment.Pay(amount);
    }
}
