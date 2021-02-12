using NUnit.Framework;

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
        public void CanAddAnItemToCheckoutBasket()
        {
            var sut = new CheckoutService();

            sut.Add("A");

            Assert.Pass();
        }
    }
}