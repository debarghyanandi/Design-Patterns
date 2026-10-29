namespace DesignPatterns.Creational.Builder;

// Why:  an Order is only valid once it is complete (at least one item, coupon only on 500+),
//       so one gate — Build() — checks it before the object exists.
// Flow: new Order.Builder(customer) → steps return this → Build() validates → immutable Order.
// Cost: two classes for one object. For flat data with no cross-field rules, required/init is enough.
// How:  nested Builder calls Order's private constructor; Build() copies the item list.
public sealed class Order
{
    public enum Shipping { Standard, Express }

    public sealed record LineItem(string Sku, int Quantity, decimal UnitPrice)
    {
        public decimal Total => Quantity * UnitPrice;
    }

    public string CustomerId { get; }
    public IReadOnlyList<LineItem> Items { get; }
    public Shipping Speed { get; }
    public string? Coupon { get; }
    public decimal Subtotal => Items.Sum(i => i.Total);

    private Order(string customerId, IReadOnlyList<LineItem> items, Shipping speed, string? coupon)
        => (CustomerId, Items, Speed, Coupon) = (customerId, items, speed, coupon);

    public sealed class Builder
    {
        private readonly string _customerId;
        private readonly List<LineItem> _items = [];
        private Shipping _speed = Shipping.Standard;
        private string? _coupon;

        // Required part goes in the constructor; optional parts are steps.
        public Builder(string customerId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(customerId);
            _customerId = customerId;
        }

        // A step checks only its own arguments.
        public Builder AddItem(string sku, int quantity, decimal unitPrice)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            _items.Add(new LineItem(sku, quantity, unitPrice));
            return this;
        }

        public Builder Express() { _speed = Shipping.Express; return this; }

        public Builder WithCoupon(string code) { _coupon = code; return this; }

        // Rules across fields live here — the one gate.
        public Order Build()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("An order needs at least one item.");
            if (_coupon is not null && _items.Sum(i => i.Total) < 500m)
                throw new InvalidOperationException("A coupon needs a subtotal of at least 500.");

            return new Order(_customerId, [.. _items], _speed, _coupon); // copy: later steps can't leak in
        }
    }
}
