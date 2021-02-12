namespace Checkout
{
    public class ItemPrice
    {
        public string Sku { get; }

        public decimal UnitPrice { get; }

        public ItemPrice(string sku, decimal unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }
}