using NUnit.Framework;

using System;

namespace Checkout.Tests
{
    public class CheckoutServiceTests
    {
        [Test]
        public void CanUseCheckoutServiceTest()
        {
            var sut = new CheckoutService();

            Assert.That(sut, Is.Not.Null);
        }

        [TestCase("A", ExpectedResult = 10)]
        [TestCase("B", ExpectedResult = 15)]
        public decimal AddedItemB_ThenTotalIs15(string sku)
        {
            var sut = new CheckoutService();

            sut.Add(sku);

            return sut.GetTotal();
        }
    }
}