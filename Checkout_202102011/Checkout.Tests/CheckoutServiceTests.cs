using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace Checkout.Tests
{
    public class CheckoutServiceTests
    {
        private IList<ItemPrice> _itemPrices;

        private IList<IItemPromotion> _itemPromotions;

        [SetUp]
        public void Init()
        {
           _itemPrices = new List<ItemPrice>
             {
                 new ItemPrice("A", 10m),
                 new ItemPrice("B", 15m),
                 new ItemPrice("C", 40m),
                 new ItemPrice("D", 55m)
             };

           _itemPromotions = new List<IItemPromotion>();
        }

        [Test]
        public void CanUseCheckoutServiceTest()
        {
            var sut = new CheckoutService(_itemPrices, _itemPromotions);

            Assert.That(sut, Is.Not.Null);
        }

        [TestCase("A", ExpectedResult = 10)]
        [TestCase("B", ExpectedResult = 15)]
        [TestCase("C", ExpectedResult = 40)]
        [TestCase("D", ExpectedResult = 55)]
        public decimal AddedSingleItem_ThenTotalIsAsExpected(string sku)
        {
            var sut = new CheckoutService(_itemPrices, _itemPromotions);

            sut.Add(sku);

            return sut.GetTotal();
        }

        [TestCase("A B", ExpectedResult = 25)]
        [TestCase("B A", ExpectedResult = 25)]
        [TestCase("C D", ExpectedResult = 95)]
        [TestCase("D C B A", ExpectedResult = 120)]
        public decimal AddedManyItems_ThenTotalIsAsExpected(string skuList)
        {
            var sut = new CheckoutService(_itemPrices, _itemPromotions);

            var skus = skuList.Split(" ");
            foreach (var sku in skus)
            {
                sut.Add(sku);
            }

            return sut.GetTotal();
        }

        [TestCase("B B B", ExpectedResult = 40)]
        [TestCase("B B B B", ExpectedResult = 55)]
        [TestCase("B B B B B B", ExpectedResult = 80)]
        public decimal AddedMultiple3OfItemsB_ThenPromotion3For40ShouldBeApplied(string skuList)
        {
            var itemPromotion3For40 = new ItemPromotion(skuList.Substring(0,1), 3, 40);
            _itemPromotions.Add(itemPromotion3For40);
            var sut = new CheckoutService(_itemPrices, _itemPromotions);

            var skus = skuList.Split(" ");
            foreach (var sku in skus)
            {
                sut.Add(sku);
            }

            return sut.GetTotal();
        }
    }
}