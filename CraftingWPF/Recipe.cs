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
    }
}