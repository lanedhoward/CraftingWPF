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
    }
}
