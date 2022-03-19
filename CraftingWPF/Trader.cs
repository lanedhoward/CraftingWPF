using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CraftingWPF;
using static CraftingWPF.WPFUtils;

namespace CraftingSystemDemo
{
    class Trader : Person
    {
        public Trader()
        {
            // initialize variables
            Name = "Ol' Shopkeep Steve";
            Money = 100;

            //initialize inventory
            RedDye redDye = new RedDye(5) { Price = 1 };
            BlueDye blueDye = new BlueDye(5) { Price = 1 };


            Inventory.Add(redDye);
            Inventory.Add(blueDye);

            UpdateInventoryDisplay();
        }

        public void StartDialogue(Player player)
        {
            Say("Well hey there, stranger! Can I interest you in some wares?");
            Print($"[You have {player.Money.ToString("C")}]");
            UpdateInventoryDisplay();



        }

        public void EndDialogue()
        {
            Say("See ya' later!");
        }

        public void UpdateInventoryDisplay()
        {
            //Inventory = Inventory.OrderBy(item => item.Name).ToList(); //linq implementation
            Inventory.Sort(); // list sort implementation. to sort in place and also show interface inheritance. 
            WPFUtils.RefreshListBoxDataBinding(WPFUtils.ShopInventoryBox, Inventory);
        }

        public void PlayerBuy(Player player, Item i)
        {
            if (i.Price <= player.Money)
            {
                //buy the item
                double transferAmount = 1;
                if (i.Quantity < 1) transferAmount = i.Quantity;

                player.Money -= i.Price * transferAmount;

                GameUtils.TransferItem(i, Inventory, player.Inventory);

                Say($"All yours, pal! Enjoy the {i.Name}.");
                Print($"[You have {player.Money.ToString("C")} remaining.]");
                

                UpdateInventoryDisplay();
                player.UpdateInventoryDisplay();

            }
            else
            {
                // not enough money
                Say("Er... your pockets are lookin' a bit too light there.");
                Print("[Error: Insufficient funds]");
            }
        }

        public void PlayerSell(Player player, Item i)
        {
            
            //sell the item
            

            GameUtils.TransferItem(i, player.Inventory, Inventory);

            double multiplier = 1;

            /* this logic has been moved to the crafting section
            double chance = GameUtils.random.NextDouble();
            if (chance > 0.9)
            {
                //very rare item
                multiplier = 2;
            }
            else if (chance > 0.7)
            {
                //rare item
                multiplier = 1.5;
                
            }
            else
            {
                //traders gotta make a profit somehow
                multiplier = 0.9;
            }
            */

            double transferAmount = 1;
            if (i.Quantity < 1) transferAmount = i.Quantity;

            double buyPrice = i.Price * multiplier * transferAmount;
            player.Money += buyPrice;

            Say($"I'll take that {Item.QualityName(i.Quality)} {i.Name} for {buyPrice.ToString("C")}.");
            Print($"[You have {player.Money.ToString("C")} remaining.]");


            UpdateInventoryDisplay();
            player.UpdateInventoryDisplay();

            
        }

    }



}
