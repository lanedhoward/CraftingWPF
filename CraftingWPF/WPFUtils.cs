using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CraftingSystemDemo;

namespace CraftingWPF
{
    static class WPFUtils
    {
        public static TextBox OutputBox;
        public static TextBox InventoryDisplay;
        public static ListBox RecipesListBox;

        public static void Print(string message)
        {
            // some help from https://stackoverflow.com/questions/18260702/textbox-appendtext-not-autoscrolling
            OutputBox.AppendText(message + "\n");
            //appendtext should scroll automatically but sometimes it wasn't so i did this
            OutputBox.ScrollToEnd();
            
        }
        public static void Print()
        {
            Print("");
        }

        public static void Clear()
        {
            OutputBox.Text = "";
        }

        public static void UpdateInventoryDisplay(List<Item> items)
        {
            InventoryDisplay.Text = ConsoleUtils.ShowAllItemsInList(items,false);
        }

        public static void RefreshListBoxDataBinding(ListBox lb, List<Recipe> list)
        {
            lb.ItemsSource = null;
            lb.ItemsSource = list;
        }

    }
}
