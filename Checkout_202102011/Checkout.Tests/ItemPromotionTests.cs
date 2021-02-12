using NUnit.Framework;

namespace Checkout.Tests
{
    public class ItemPromotionTests
    {
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(6)]
        public void CanApplyDiscount_GivenValidSkuAndNumberOfItems_ReturnsTrue(int numberOfItemsInBasket)
        {
            const string sku = "X";
            const int numberOfItemsForPromotion = 3;
            var sut = new ItemPromotion(sku, numberOfItemsForPromotion, 20m);

            var actual = sut.CanApplyDiscount(sku, numberOfItemsInBasket);
        }
    }
}