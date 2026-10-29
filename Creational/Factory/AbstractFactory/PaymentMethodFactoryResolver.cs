namespace DesignPatterns.Creational.Factory.AbstractFactory;

// Chooses WHICH family to use, from user input.
// It is a Simple Factory that returns a whole factory instead of one product.
//
// It runs once, at the EDGE of the program (Program.cs here, the DI setup in a real app).
// It never runs inside OrderService - the client must not know about "upi" or "card".
//
// In ASP.NET Core, DI usually does this job, e.g. with keyed services (.NET 8+):
//   services.AddKeyedSingleton<IPaymentMethodFactory, UpiFactory>("upi");
public static class PaymentMethodFactoryResolver
{
    public static IPaymentMethodFactory Resolve(string method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(method);

        return method.Trim().ToLowerInvariant() switch
        {
            "card"   => new CardFactory(),
            "upi"    => new UpiFactory(),
            "wallet" => new WalletFactory(),
            _ => throw new ArgumentException($"Unknown payment method: '{method}'.", nameof(method))
        };
    }
}
