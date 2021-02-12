using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class CheckoutService
    {
        private readonly IList<ItemPrice> _itemPrices;

        private readonly IList<IItemPromotion> _itemPromotions;

        private IList<string> _basketItems;

        public CheckoutService(IList<ItemPrice> itemPrices, IList<IItemPromotion> itemPromotions)
        {
            _itemPrices = itemPrices;
            _itemPromotions = itemPromotions;
            _basketItems = new List<string>();
        }

        public void Add(string sku)
        {
            _basketItems.Add(sku);
        }

        public decimal GetTotal()
        {
            return _basketItems.Sum(sku => _itemPrices.Single(x => x.Sku == sku).UnitPrice);
        }
    }
}
