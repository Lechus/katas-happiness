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

        [Test]
        public void AddedItemA_ThenTotalIs10()
        {
            var sut = new CheckoutService();

            sut.Add("A");

            decimal total = sut.GetTotal();

            Assert.That(total, Is.EqualTo(10m));
        }

        [Test]
        public void AddedItemB_ThenTotalIs15()
        {
            var sut = new CheckoutService();

            sut.Add("B");

            decimal total = sut.GetTotal();

            Assert.That(total, Is.EqualTo(15m));
        }
    }
}