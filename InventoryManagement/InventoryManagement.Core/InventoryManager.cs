using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Core
{
    public class InventoryManager
    {
        public string UpdateInventory(string listOfItems)
        {
            var items = listOfItems.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var updatedItems = UpdateItems(items);

            return string.Join(Environment.NewLine, updatedItems);
        }

        private IEnumerable<string> UpdateItems(string[] items)
        {
            return items.Select(UpdateItem);
        }

        private string UpdateItem(string item)
        {
            if (!item.Contains("Soap")) return "NO SUCH ITEM";
            return item;
        }
    }
}
