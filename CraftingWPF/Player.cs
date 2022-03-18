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

            
            WPFUtils.RecipesListBox.ItemsSource = KnownRecipes;
            
        }

        public void UpdateInventoryDisplay()
        {
            WPFUtils.UpdateInventoryDisplay(Inventory);
        }

        public override bool Craft(Recipe recipe, out double quality)
        {
            
            bool result = base.Craft(recipe, out quality);
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
