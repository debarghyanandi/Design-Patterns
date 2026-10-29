namespace DesignPatterns.Creational.Factory.Payments;

// PRODUCT kind 1: paying.
// Shared by all three factories (Simple Factory, Factory Method, Abstract Factory),
// so each pattern creates the same classes and only the way of creating them changes.
public interface IPayment
{
    void Pay(decimal amount);
}

public sealed class CardPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Card payment successful: {amount:0.00}");
}

public sealed class UpiPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"UPI payment successful: {amount:0.00}");
}

public sealed class WalletPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Wallet payment successful: {amount:0.00}");
}
