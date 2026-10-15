using DesignPatterns.Creational.Factory.AbstractFactory;
using DesignPatterns.Creational.Factory.FactoryMethod;
using DesignPatterns.Creational.Factory.SimpleFactory;

// ======================= 1. Simple Factory =======================
// One static method picks ONE product from a string.
Console.WriteLine("--- Simple Factory ---");

var checkout = new Checkout();
checkout.Pay("Upi", 21.22m);                                      // any casing works - the factory normalises it
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

// ======================= 2. Factory Method =======================
// A SUBCLASS picks ONE product; the base class runs the shared workflow.
Console.WriteLine();
Console.WriteLine("--- Factory Method ---");

PaymentProcessor wallet = new WalletProcessor();
wallet.ProcessPayment(123m);

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

// ======================= 3. Abstract Factory =======================
// A FACTORY OBJECT creates a whole FAMILY (payment + refund) that always matches.
Console.WriteLine();
Console.WriteLine("--- Abstract Factory ---");

string[] methods = ["card", "upi", "wallet"];                     // in a real app: from the request

foreach (string method in methods)
{
    IPaymentMethodFactory factory = PaymentMethodFactoryResolver.Resolve(method); // 1. at the edge: choose the family ONCE
    var orderService = new OrderService(factory);                                 // 2. hand the factory to the client

    orderService.Pay(500m);                                                       // 3. payment and refund come from the
    orderService.Refund(500m);                                                    //    same factory, so they always match
}

try
{
    PaymentMethodFactoryResolver.Resolve("cash");                 // an unknown family must fail loudly too
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Rejected: {ex.Message}");
}
