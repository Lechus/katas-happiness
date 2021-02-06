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
    }
}
