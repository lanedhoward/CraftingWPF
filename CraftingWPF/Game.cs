using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftingWPF.WPFUtils;
using CraftingWPF;
using System.Windows.Threading;

namespace CraftingSystemDemo
{

    class Game
    {
        public Player MyPlayer;
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                Print();
            }

            Print("Hello World");

            
            

            MyPlayer = new Player();


            MyPlayer.Name = "Player";

            Print("Welcome " + MyPlayer.Name);

            Print(ConsoleUtils.LoadTextFromFile("../../../data/welcome.txt"));
            Print(ConsoleUtils.LoadTextFromFile("../../../data/instructions.txt"));
            

            MyPlayer.Inventory = ConsoleUtils.LoadItemListFromFile("../../../data/startingInventory.txt");
            //Print(ConsoleUtils.ShowAllItemsInList(MyPlayer.Inventory, false));
            MyPlayer.UpdateInventoryDisplay();



            Recipe chamomileTea = new Recipe(
                new List<Item>()
                {
                    new Item(1, "Water"),
                    new Item(1, "Chamomile")

                },
                new Item(1, "Chamomile Tea")
                );
            

            
            Recipe sleepingPotion = new Recipe(
                new List<Item>()
                {
                    new Item(1, "Chamomile Tea"),
                    new Item(.5, "Ashwagandha"),
                    new Item(.5, "Dried Lavender"),
                    new Item(.5, "Lemon Balm")

                },
                new Item(1, "Sleeping Potion")
                );

            MyPlayer.LearnRecipe(chamomileTea);
            MyPlayer.LearnRecipe(sleepingPotion);



            /*
            MyPlayer.Craft(chamomileTea);
            Print(ConsoleUtils.ShowAllItemsInList(MyPlayer.Inventory, false));

            MyPlayer.Craft(sleepingPotion);
            Print(ConsoleUtils.ShowAllItemsInList(MyPlayer.Inventory, false));
            */
            //Trader MyTrader = new Trader();
            //MyTrader.StartDialogue(MyPlayer);



            
        }

        public void buttonCraft_Click()
        {
            //get selected recipe from list box
            Recipe recipe = (Recipe) RecipesListBox.SelectedItem;

            if (recipe != null)
            {
                //craft it
                bool success = MyPlayer.Craft(recipe);
                if (success)
                {
                    Print("Crafting success!");
                }
                else
                {
                    //craft failed
                    Print("[Error: Crafting failed.]");
                }
            }
            else
            {
                Print("[Error: Please select a recipe to craft.]");
            }




        }

    }
}
