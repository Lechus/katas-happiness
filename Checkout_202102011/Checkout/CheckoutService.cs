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
    }
}
