using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace Checkout.Tests
{
    public class CheckoutServiceTests
    {
        private IList<ItemPrice> _itemPrices;

        [SetUp]
        public void Init()
        {
           _itemPrices = new List<ItemPrice>
             {
                 new ItemPrice("A", 10m),
                 new ItemPrice("B", 15m)
             };
        }

        [Test]
        public void CanUseCheckoutServiceTest()
        {
            var sut = new CheckoutService(_itemPrices);

            Assert.That(sut, Is.Not.Null);
        }

        [TestCase("A", ExpectedResult = 10)]
        [TestCase("B", ExpectedResult = 15)]
        public decimal AddedItemB_ThenTotalIs15(string sku)
        {
            var sut = new CheckoutService(_itemPrices);

            sut.Add(sku);

            return sut.GetTotal();
        }
    }
}