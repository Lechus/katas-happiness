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
            IItemPromotion sut = new ItemPromotion(sku, numberOfItemsForPromotion, 20m);

            var actual = sut.CanApplyDiscount(sku, numberOfItemsInBasket);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void CalculateDiscount_GivenLowerNumberOfItemsThenTheMinumum_Returns0(int numberOfItemsInBasket)
        {
            const string sku = "X";
            const int numberOfItemsForPromotion = 3;
            IItemPromotion sut = new ItemPromotion(sku, numberOfItemsForPromotion, 20m);

            var actual = sut.CalculateDiscount(numberOfItemsInBasket, 10m);

            Assert.That(actual, Is.EqualTo(0m));
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void CalculateDiscount_GivenItemsForSingleDiscount_Returns10(int numberOfItemsInBasket)
        {
            const string sku = "X";
            const int numberOfItemsForPromotion = 3;
            IItemPromotion sut = new ItemPromotion(sku, numberOfItemsForPromotion, 20m);

            var actual = sut.CalculateDiscount(numberOfItemsInBasket, 10m);

            Assert.That(actual, Is.EqualTo(10m));
        }

        [TestCase(6, 2)]
        [TestCase(9, 3)]
        [TestCase(33, 11)]
        public void CalculateDiscount_GivenItemsForManyDiscounts_ReturnsExpectedDiscount(int numberOfItemsInBasket, int numberOfDiscounts)
        {
            const string sku = "X";
            const int numberOfItemsForPromotion = 3;
            IItemPromotion sut = new ItemPromotion(sku, numberOfItemsForPromotion, 20m);

            var actual = sut.CalculateDiscount(numberOfItemsInBasket, 10m);

            Assert.That(actual, Is.EqualTo(10m * numberOfDiscounts));
        }
    }
}