using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.AbstractFactory;

// ABSTRACT FACTORY (GoF)
//
// Why:  a payment and its refund must use the SAME rails. A UPI payment refunded as a
//       CardRefund compiles fine but is a production incident. If one factory creates the
//       whole family, the client cannot mix them.
// Family: one payment method = { IPayment, IRefund } for Card, UPI or Wallet.
// How:  COMPOSITION - the client is HANDED a factory object (it does not inherit from one).
// Cost: a new FAMILY (e.g. NetBanking) = one new class below. Cheap.
//       A new PRODUCT KIND (e.g. IReceipt) = edit this interface AND every factory. Expensive.
//       So use it when families get added and the list of product kinds stays stable.

// The abstract factory: one Create method per product kind.
public interface IPaymentMethodFactory
{
    IPayment CreatePayment();
    IRefund CreateRefund();
}

// One concrete factory per family. Each one returns ONLY its own family's products.

public sealed class CardFactory : IPaymentMethodFactory
{
    public IPayment CreatePayment() => new CardPayment();
    public IRefund CreateRefund() => new CardRefund();
}

public sealed class UpiFactory : IPaymentMethodFactory
{
    public IPayment CreatePayment() => new UpiPayment();
    public IRefund CreateRefund() => new UpiRefund();
}

public sealed class WalletFactory : IPaymentMethodFactory
{
    public IPayment CreatePayment() => new WalletPayment();
    public IRefund CreateRefund() => new WalletRefund();
}
