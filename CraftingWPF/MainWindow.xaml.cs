using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CraftingSystemDemo;

namespace CraftingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    /*
     * Credits:
     * Color Palette from https://lospec.com/palette-list/slso8
     * 
     */
    public partial class MainWindow : Window
    {
        Game myGame;
        public MainWindow()
        {
            InitializeComponent();

            WPFUtils.OutputBox = tboxOutput;
            WPFUtils.InventoryBox = lboxInventory;
            WPFUtils.ShopInventoryBox = lboxShopInventory;
            WPFUtils.RecipesListBox = lboxRecipes;

            buttonBuy.Visibility = Visibility.Hidden;
            buttonSell.Visibility = Visibility.Hidden;
            lboxShopInventory.Visibility = Visibility.Hidden;

            myGame = new Game();
            
        }
        void OnLoad(object sender, RoutedEventArgs e)
        {
            // heard about load events in passing from looking something else up, learned this code from the c# documentation
            myGame.Run();
        }
        private void tblockInventory_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonCraft_Click(object sender, RoutedEventArgs e)
        {
            myGame.buttonCraft_Click();
        }

        private void buttonShop_Click(object sender, RoutedEventArgs e)
        {
            // toggle visibility
            if(myGame.ShopOpen)
            {
                buttonBuy.Visibility = Visibility.Hidden;
                buttonSell.Visibility = Visibility.Hidden;
                lboxShopInventory.Visibility = Visibility.Hidden;
                buttonShop.Content = "Talk to Shopkeep";
            }
            else
            {
                buttonBuy.Visibility = Visibility.Visible;
                buttonSell.Visibility = Visibility.Visible;
                lboxShopInventory.Visibility = Visibility.Visible;
                buttonShop.Content = "Say goodbye to Shopkeep";
            }

            myGame.buttonShop_Click();


        }

        private void buttonBuy_Click(object sender, RoutedEventArgs e)
        {
            myGame.buttonBuy_Click();
        }

        private void buttonSell_Click(object sender, RoutedEventArgs e)
        {
            myGame.buttonSell_Click();
        }

        private void lboxRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myGame.lboxRecipes_SelectionChanged();
        }
    }
}
