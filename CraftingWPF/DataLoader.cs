using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using CraftingSystemDemo;

namespace CraftingWPF
{
    class DataLoader
    {

        public static List<Recipe> LoadRecipesFromXML(string path)
        {
            List<Recipe> results = new List<Recipe>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root = doc.DocumentElement;

            XmlNodeList recipeList = root.SelectNodes("/recipes/recipe");

            foreach (XmlElement r in recipeList)
            {
                Item recipeResult = new Item(double.Parse(r.GetAttribute("quantity")), r.GetAttribute("itemName"));

                XmlNodeList ingredientsList = r.ChildNodes;

                List<Item> requirements = new List<Item>();

                foreach(XmlElement i in ingredientsList)
                {
                    Item ingredient = new Item(double.Parse(i.GetAttribute("quantity")), i.GetAttribute("itemName"));
                    requirements.Add(ingredient);
                }

                Recipe recipe = new Recipe(requirements, recipeResult);
                results.Add(recipe);

            }

            return results;
        }

    }
}
