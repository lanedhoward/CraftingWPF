using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftingSystemDemo
{
    public class Recipe
    {
        public List<Item> requirements;
        public Item result;

        public Recipe(List<Item> _requirements, Item _result)
        {
            requirements = _requirements;
            result = _result;
        }

        public override string ToString()
        {
            return result.Name;
        }

        public string StringOfRecipe()
        {
            string s = "";

            s += result.Quantity + " " + result.Name + ": ";

            for (int i = 0; i < requirements.Count; i++)
            {
                s += requirements[i].Quantity + " " + requirements[i].Name;
                if (i < requirements.Count-1)
                {
                    //not the last one, add a comma
                    s += ", ";
                }

            }

            return s;

        }

    }
}