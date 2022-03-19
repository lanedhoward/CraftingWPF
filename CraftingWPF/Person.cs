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
        

        
        public virtual bool Craft(Recipe recipe, out double quality)
        {
            bool success = true;
            Item result;
            double totalPrice = 0;


            quality = Item.Standard;


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
                        //found item
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
                //actually execute the craft
                foreach (Item item in recipe.requirements)
                {

                    //get name of requirement
                    string name = item.Name;
                    double quantity = item.Quantity;
                    
                    foreach (Item i in Inventory)
                    {
                        if (i.Name == name && i.Quantity >= quantity)
                        {
                            totalPrice += i.Price * quantity;
                            //if it works, reduce quantity / remove from inventory
                            if (i.Quantity == quantity)
                            {

                                Inventory.Remove(i);
                            }
                            else
                            {
                                i.Quantity -= quantity;
                            }
                            break;
                        }

                    }
                }


                result = Item.ItemClone(recipe.result);

                Dictionary<double, int> potentialProfitMarginsDict = new Dictionary<double, int>()
                {
                    {Item.Middling, 15 }, //70% chance to be 10-12% profit
                    {Item.Standard, 40 },
                    {Item.Fine, 15 },
                    {Item.Rare, 20 }, //20% chance of above average
                    {Item.Outstanding, 10 } //10% chance to be rare
                };
                double profitMargin = ChooseWeighted<double>(potentialProfitMarginsDict);
                
                result.Price = Math.Round(totalPrice * profitMargin, 2);
                result.Quality = profitMargin;
                quality = profitMargin;

                var searchResults = GameUtils.SearchInventoryByName(result.Name, Inventory);

                if (searchResults.Item1 && searchResults.Item2.Price == result.Price)
                {
                    //already had a stack, just add the new quantity
                    searchResults.Item2.Quantity += result.Quantity;
                    
                }
                else
                {
                    //no stack of the same name and price, make a new stack
                    Inventory.Add(result);
                }
            }
            else
            {
                //crafting failed, no items were changed
            }
            
            return success;
        }
        
    }
}