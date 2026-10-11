namespace DesignPatterns.Creational.Factory.Payments;

// The products. Every factory in this project creates one of these.
// Shared, so Simple Factory, Factory Method and Abstract Factory all use the same classes.
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
