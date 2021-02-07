using NUnit.Framework;

using System;

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

        [Test]
        public void GivenListOfSoapAndInvalidItem_ReturnsListOfSoapAndNoSuchItem()
        {
            var sut = new InventoryManager();

            var listOfItems = "Soap 2 2" + Environment.NewLine + "Invalid Item 2 2";

            var result = sut.UpdateInventory(listOfItems);

            var lines = result.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.That(lines[0], Is.EqualTo("Soap 2 2"));
            Assert.That(lines[1], Is.EqualTo("NO SUCH ITEM"));
        }
    }
}
