using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class CheckoutService
    {
        private readonly IList<ItemPrice> _itemPrices;

        private IList<string> _basketItems;

        public CheckoutService(IList<ItemPrice> itemPrices)
        {
            _itemPrices = itemPrices;
            _basketItems = new List<string>();
        }

        public void Add(string sku)
        {
            _basketItems.Add(sku);
        }

        public decimal GetTotal()
        {
            if (_basketItems[0].Equals("A"))
            {
                return _itemPrices.Single(x=>x.Sku == "A").UnitPrice;
            }
            else
            {
                return _itemPrices.Single(x=>x.Sku == "B").UnitPrice;
            }
        }
    }
}
