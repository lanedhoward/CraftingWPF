using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingSystemDemo
{
    class GameUtils
    {
        public static Random random = new Random();
        public static string ShowAllItemsInList(List<Item> items, bool showPrice)
        {
            string output = "";
            int index = 1;
            // since this is player facing, it should be 1 indexed. 
            //keep this in mind whenever picking something out of the list

            foreach (Item item in items)
            {

                // every item will have a quantity and a name.
                output += "  [" + index + "]" + "   " + item.Quantity + " " + item.Name;

                //some will have a description, so if they have one, show it
                if (item.Description != "" && item.Description != null)
                {
                    output += ": " + item.Description;
                }

                //showPrice is for shops and such
                if (showPrice)
                {
                    output += " ---- " + item.Price.ToString("C");
                }

                //end with a new line
                output += "\n";

                //increment index
                index += 1;
            }

            return output;
        }

        public static (bool, Item) SearchInventoryByName(string name, List<Item> inventory)
        {
            Item resultItem = new Item(1,"Garbage");
            bool success = false;
            foreach (Item i in inventory)
            {
                if (i.Name == name)
                {
                    resultItem = i;
                    success = true;
                    break;
                }
            }
            return (success, resultItem);
        }

        public static void TransferItem(Item item, List<Item> source, List<Item> destination)
        {
            //see if there is an item stack by that name in the destination inventory
            var searchResults = SearchInventoryByName(item.Name, destination);
            double transferAmount = 1;

            if (searchResults.Item1) //if successfully found item in destination inventory
            {
                if (item.Quantity == 1)
                {
                    // only one item, just move it
                    source.Remove(item);
                }
                else if (item.Quantity < 1)
                {
                    //fractional stack, remove it all
                    transferAmount = item.Quantity;
                    source.Remove(item);
                }
                else
                {
                    // but what if the item is in a stack??
                    item.Quantity -= 1;
                }
                searchResults.Item2.Quantity += transferAmount;
            }
            else //no stack in destination to add to
            {
                if (item.Quantity == 1)
                {
                    // only one item, just move it
                    source.Remove(item);
                    destination.Add(item);
                }
                else if (item.Quantity < 1)
                {
                    //less than 1 item, move it
                    source.Remove(item);
                    destination.Add(item);
                }
                else
                {
                    // but what if the item is in a stack??
                    Item newItem = Item.ItemClone(item);
                    newItem.Quantity = 1;
                    destination.Add(newItem);
                    item.Quantity -= 1;
                }
            }
            // but what if the player already has a stack of the item??
        }

    }
}
