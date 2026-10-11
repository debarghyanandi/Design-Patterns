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
// Your Factory Method version goes in the FactoryMethod/ folder, called from here.
