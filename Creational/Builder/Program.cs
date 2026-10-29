using DesignPatterns.Creational.Builder;

var builder = new Order.Builder("C-42")
    .AddItem("KEYBOARD", 2, 300m)
    .Express()
    .WithCoupon("SAVE10");

var order = builder.Build();
Print(order);

builder.AddItem("MOUSE", 1, 50m); // change the builder after Build()
Console.WriteLine($"Built order still has {order.Items.Count} item(s).");

Try("no items", () => new Order.Builder("C-1").Build());
Try("coupon under 500", () => new Order.Builder("C-1").AddItem("PEN", 1, 20m).WithCoupon("SAVE10").Build());
Try("zero quantity", () => new Order.Builder("C-1").AddItem("PEN", 0, 20m));

static void Print(Order o) =>
    Console.WriteLine($"{o.CustomerId}: {o.Items.Count} item(s), {o.Speed}, coupon {o.Coupon ?? "none"}, subtotal {o.Subtotal}");

static void Try(string name, Action act)
{
    try { act(); Console.WriteLine($"{name}: no error — bug"); }
    catch (Exception e) when (e is InvalidOperationException or ArgumentException)
    { Console.WriteLine($"{name}: {e.Message}"); }
}
