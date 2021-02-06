namespace InventoryManagement.Core
{
    public class InventoryManager
    {
        public string UpdateInventory(string listOfItems)
        {
            if (!listOfItems.Contains("Soap")) return "NO SUCH ITEM";
            return listOfItems;
        }
    }
}
