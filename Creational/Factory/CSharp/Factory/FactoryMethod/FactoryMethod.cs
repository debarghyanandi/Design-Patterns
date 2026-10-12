using DesignPatterns.Creational.Factory.Payments;

namespace DesignPatterns.Creational.Factory.FactoryMethod
{
    public abstract class PaymentProcessor
    {
        protected abstract IPayment CreatePayment();

        public void ProcessPayment(decimal amount)
        {
            IPayment payment = CreatePayment();
            payment.Pay(amount);
        }
    }

    public class CardProcessor : PaymentProcessor
    {
        protected override IPayment CreatePayment()
        {
            return new CardPayment();
        }
    }

    public class UpiProcessor : PaymentProcessor
    {
        protected override IPayment CreatePayment()
        {
            return new UpiPayment();
        }
    }

    public class WalletProcessor : PaymentProcessor
    {
        protected override IPayment CreatePayment()
        {
            return new WalletPayment();
        }
    }
}
