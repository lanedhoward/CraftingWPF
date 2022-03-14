using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftingWPF;

namespace CraftingSystemDemo
{
    class Player : Person
    {

        public List<Recipe> KnownRecipes = new List<Recipe>();
        public Player()
        {
            // initialize variables
            Money = 15;

            Inventory = new List<Item>();

            //starting player inventory
            Inventory.Add(new Item(2, "Toadstool"));
            Inventory.Add(new Item(10, "Feather", "From a bird, probably"));
            Inventory.Add(new Item(3, "Seaweed"));

            WPFUtils.RecipesListBox.ItemsSource = KnownRecipes;
            
        }

        public void UpdateInventoryDisplay()
        {
            WPFUtils.UpdateInventoryDisplay(Inventory);
        }

        public override bool Craft(Recipe recipe)
        {
            bool result = base.Craft(recipe);
            UpdateInventoryDisplay();
            return result;
        }

        public void LearnRecipe(Recipe recipe)
        {
            KnownRecipes.Add(recipe);
            WPFUtils.RefreshListBoxDataBinding(WPFUtils.RecipesListBox, KnownRecipes);
        }

    }
}
