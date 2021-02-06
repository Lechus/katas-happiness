using NUnit.Framework;

namespace InventoryManagement.Core.UnitTests
{
    [TestFixture]
    public class InventoryManagerTests
    {     
        [Test]
        public void GivenSoap_ReturnsNotChangedSoap()
        {
            var sut = new InventoryManager();

            var listOfItems = "Soap 2 2";

            var result = sut.UpdateInventory(listOfItems);

            Assert.That(result, Is.EqualTo(listOfItems));
        }

        [Test]
        public void GivenInvalidItem_ReturnsNoSuchItem()
        {
            var sut = new InventoryManager();

            var listOfItems = "Invalid Item 2 2";

            var result = sut.UpdateInventory(listOfItems);

            Assert.That(result, Is.EqualTo("NO SUCH ITEM"));
        }
    }
}
