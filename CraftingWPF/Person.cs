using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using CraftingWPF;
using static CraftingWPF.WPFUtils;

namespace CraftingSystemDemo
{
    public class Person
    {
        public string Name;
        public double Money;

        public List<Item> Inventory = new List<Item>();

        public void Say(string line)
        {
            // Use Say method to keep dialogue formatting consistent across all people
            Print(Name + ": " + line);
        }
        

        
        public virtual bool Craft(Recipe recipe)
        {
            bool success = true;
            Item result;
            List<Item> startingInventory = Inventory; //saved in case we need to revert

            foreach (Item item in recipe.requirements)
            {
                
                //get name of requirement
                string name = item.Name;
                double quantity = item.Quantity;
                bool minisuccess = false; // success at finding each item
                // search inventory for item of same name
                // if there is one, check if quantity is enough
                foreach (Item i in Inventory)
                {
                    

                    if (i.Name == name && i.Quantity >= quantity)
                    {
                        //if it works, reduce quantity / remove from inventory
                        if (i.Quantity == quantity)
                        {
                            // removing from inventory caused exception, will fix later
                            Inventory.Remove(i);
                        }
                        else
                        {
                            i.Quantity -= quantity;
                        }


                        minisuccess = true;
                        break;
                    }
                    
                }

                if (minisuccess == false)
                {
                    // if we finished a loop of inventory and didn't find the recipe item
                    // no mini success.
                    // no mini success means missing an item, so overall crafting success cant work.
                    success = false;
                }
                

                // else, success = false and stop looping
                if (success == false)
                {
                    break;
                }
            }

            if (success)
            {
                result = recipe.result;
                Inventory.Add(result);
            }
            else
            {
                //revert inventory, in case some of the items were used but not all
                Inventory = startingInventory;
            }
            
            return success;
        }
        
    }
}