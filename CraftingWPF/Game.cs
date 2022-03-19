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
        public bool ShopOpen = false;
        public Trader MyTrader;

        public void Run()
        {
            
            MyPlayer = new Player();
            MyPlayer.Name = "Player";

            Print(ConsoleUtils.LoadTextFromFile("../../../data/welcome.txt"));
            Print(ConsoleUtils.LoadTextFromFile("../../../data/instructions.txt"));
            

            MyPlayer.Inventory = ConsoleUtils.LoadItemListFromFile("../../../data/startingInventory.txt");
            //Print(ConsoleUtils.ShowAllItemsInList(MyPlayer.Inventory, false));
            MyPlayer.UpdateInventoryDisplay();


            /*
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
            */

            List<Recipe> gameRecipes = DataLoader.LoadRecipesFromXML("../../../data/recipes.xml");
            foreach (Recipe r in gameRecipes)
            {
                MyPlayer.LearnRecipe(r);
            }

            /*
            MyPlayer.Craft(chamomileTea);
            Print(ConsoleUtils.ShowAllItemsInList(MyPlayer.Inventory, false));

            MyPlayer.Craft(sleepingPotion);
            Print(ConsoleUtils.ShowAllItemsInList(MyPlayer.Inventory, false));
            */

            MyTrader = new Trader();

            //MyTrader.StartDialogue(MyPlayer);



            
        }

        public void buttonCraft_Click()
        {
            //get selected recipe from list box
            Recipe recipe = (Recipe) RecipesListBox.SelectedItem;

            if (recipe != null)
            {
                
                //craft it
                double resultQuality;
                bool success = MyPlayer.Craft(recipe, out resultQuality);
                if (success)
                {
                    Print($"Crafting success! You made {recipe.result.Quantity} {Item.QualityName(resultQuality)} {recipe.result.Name}. ");
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

        public void buttonShop_Click()
        {
            //
            if (ShopOpen)
            {
                MyTrader.EndDialogue();
            }
            else
            {
                MyTrader.StartDialogue(MyPlayer);
            }
            ShopOpen = !ShopOpen;

        }

        public void buttonBuy_Click()
        {
            Item selectedItem = (Item) WPFUtils.ShopInventoryBox.SelectedItem;

            if (selectedItem == null)
            {
                MyTrader.Say("Er... what are you tryin' to buy?");
                Print("[Error: You must select an item first]");
            }
            else
            {
                
                MyTrader.PlayerBuy(MyPlayer, selectedItem);
            }

            
        }

        public void buttonSell_Click()
        {
            Item selectedItem = (Item)WPFUtils.InventoryBox.SelectedItem;

            if (selectedItem == null)
            {
                MyTrader.Say("Er... what are you tryin' to sell?");
                Print("[Error: You must select an item first]");
            }
            else
            {

                MyTrader.PlayerSell(MyPlayer, selectedItem);
            }
        }

        public void lboxRecipes_SelectionChanged()
        {
            Recipe selectedRecipe = (Recipe) RecipesListBox.SelectedItem;

            if (selectedRecipe != null)
            {
                //print all ingredients of the recipe
                Print(selectedRecipe.StringOfRecipe());
            }

        }
    }
}
