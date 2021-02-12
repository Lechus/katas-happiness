namespace Checkout
{
    public class ItemPromotion
    {
        private readonly string _sku;

        private readonly int _numberOfItems;

        private readonly decimal _price;

        public ItemPromotion(string sku, int numberOfItems, decimal price)
        {
            _sku = sku;
            _numberOfItems = numberOfItems;
            _price = price;
        }

        public bool CanApplyDiscount(string sku, int numberOfItems)
        {
            return (_sku.Equals(sku) && numberOfItems >= _numberOfItems);
        }
    }
}