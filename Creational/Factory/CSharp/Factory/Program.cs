using DesignPatterns.Creational.Factory.FactoryMethod;
using DesignPatterns.Creational.Factory.SimpleFactory;

Console.WriteLine("--- Simple Factory ---");
var checkout = new Checkout();
checkout.Pay("Upi", 21.22m);
checkout.Pay("Card", 2111.22m);
checkout.Pay("wallet", 2111.22m);

try
{
    checkout.Pay("cash", 10m);                                    // an unknown type must fail loudly
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Rejected: {ex.Message}");
}

Console.WriteLine("--- Factory Method ---");

PaymentProcessor wallet = new WalletProcessor();
wallet.ProcessPayment(123);

// Or

PaymentProcessor[] processors = [new CardProcessor(), new UpiProcessor(), new WalletProcessor()];
foreach (PaymentProcessor processor in processors)               // the loop sees only the base type
{
    processor.ProcessPayment(100m);
}

try
{
    new CardProcessor().ProcessPayment(0m);                       // the shared rule rejects it for every subclass
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Rejected: {ex.Message}");
}
