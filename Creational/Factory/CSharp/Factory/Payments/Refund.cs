namespace DesignPatterns.Creational.Factory.Payments;

// PRODUCT kind 2: refunding. Used by Abstract Factory.
// Why it lives in Payments/ and not in AbstractFactory/: it is a PRODUCT, not a factory.
// Products don't know which factory created them, so they sit with the other products.
//
// Each refund goes back on its own rails - that is why a payment and its refund must match.
public interface IRefund
{
    void Refund(decimal amount);
}

public sealed class CardRefund : IRefund
{
    public void Refund(decimal amount) =>
        Console.WriteLine($"Card refund started: {amount:0.00} - back to the card in 5-7 working days");
}

public sealed class UpiRefund : IRefund
{
    public void Refund(decimal amount) =>
        Console.WriteLine($"UPI refund done: {amount:0.00} - sent instantly to the payer's UPI ID");
}

public sealed class WalletRefund : IRefund
{
    public void Refund(decimal amount) =>
        Console.WriteLine($"Wallet refund done: {amount:0.00} - credited to the wallet balance");
}
