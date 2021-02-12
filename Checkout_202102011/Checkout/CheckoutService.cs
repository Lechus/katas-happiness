using System.Collections.Generic;

namespace Checkout
{
    public class CheckoutService
    {
        private IList<string> _basketItems;

        public CheckoutService()
        {
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
                return 10m;
            }
            else
            {
                return 15m;
            }
        }
    }
}
