using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.AbstractFactory;

// The CLIENT of the Abstract Factory.
// It receives a factory and asks it for products. It has no `new` for any product,
// no switch, and no concrete type name - so it cannot mix families.
//
// Flow: Program picks a factory -> new OrderService(factory)
//       -> Pay() / Refund() -> the SAME factory creates both -> they always match.
public sealed class OrderService
{
    private readonly IPaymentMethodFactory _factory;

    // Constructor injection: whoever creates OrderService decides the family.
    public OrderService(IPaymentMethodFactory factory)
    {
        ArgumentNullException.ThrowIfNull(factory);
        _factory = factory;
    }

    public void Pay(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        IPayment payment = _factory.CreatePayment();
        payment.Pay(amount);
    }

    public void Refund(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        IRefund refund = _factory.CreateRefund();                 // same factory as Pay() -> same rails
        refund.Refund(amount);
    }
}
