using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CraftingSystemDemo.ConsoleUtils;

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
            BlueDye blueDye = new BlueDye(5) { Price = 1 } ;

            
            Inventory.Add(redDye);
            Inventory.Add(blueDye);
        }

        public void StartDialogue(Player player)
        {
            Say("Well hey there, stranger! Can I interest you in some wares?");
            Say("Here's what I've got.");
            Print();
            
            Print(ShowAllItemsInList(Inventory,true));

            Say("Would you like to make a purchase? ");
            bool inputBool = GetInputBool();
            if (inputBool)
            {
                Say("What would you like to purchase?");
                GetInputInt(1, Inventory.Count);
            }



            WaitForKeyPress(true);
        }
    }
}
