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
            var total = 0m;
            var itemsGroups = _basketItems.GroupBy(x => x);

            foreach (var itemsGroup in itemsGroups)
            {
                var numberOfItemsInBasket = itemsGroup.Count();
                var sku = itemsGroup.Key;
                var itemUnitPrice = _itemPrices.Single(x => x.Sku == sku).UnitPrice;
                var itemPromotion =
                    _itemPromotions.SingleOrDefault(x => x.CanApplyDiscount(sku, numberOfItemsInBasket));
                var discountAmount = itemPromotion?.CalculateDiscount(numberOfItemsInBasket, itemUnitPrice) ?? 0m;

                total += (numberOfItemsInBasket * itemUnitPrice) - discountAmount;
            }

            return total;
        }
    }
}
