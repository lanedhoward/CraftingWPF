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
        public static ListBox RecipesListBox;
        public static ListBox InventoryBox;
        public static ListBox ShopInventoryBox;

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
            //InventoryDisplay.Text = ConsoleUtils.ShowAllItemsInList(items,false);
            RefreshListBoxDataBinding(InventoryBox, items);

        }

        public static void RefreshListBoxDataBinding(ListBox lb, List<Recipe> list)
        {
            lb.ItemsSource = null;
            lb.ItemsSource = list;
        }
        public static void RefreshListBoxDataBinding(ListBox lb, List<Item> list)
        {
            lb.ItemsSource = null;
            lb.ItemsSource = list;
        }

        //write a function like choose() from gamemaker, maybe it takes an array or a list of objects, generates a random index, and returns one of them back, to then be casted to the real type

    }
}
