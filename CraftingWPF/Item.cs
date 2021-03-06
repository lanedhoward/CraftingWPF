using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftingSystemDemo
{
    /* i would use an enum but i decided to do this with constants instead in order to use doubles.
    public enum QualityEnum : int
    {
        Middling = 1,
        Standard = 2,
        Fine = 3,
        Rare = 4,
        Outstanding = 5
    }
    */
    public class Item : IComparable
    {

        //QualityEnum q = QualityEnum.Middling;
        

        //basically setting up an enum but you cant do an enum with doubles
        public const double Middling = 1.1;
        public const double Standard = 1.11;
        public const double Fine = 1.12;
        public const double Rare = 1.5;
        public const double Outstanding = 2.0;
        
        public static string QualityName(double q)
        {
            switch (q)
            {
                case Item.Middling:
                    return "Middling";
                case Item.Standard:
                    return "Standard";
                case Item.Fine:
                    return "Fine";
                case Item.Rare:
                    return "Rare";
                case Item.Outstanding:
                    return "Outstanding";
                default:
                    return "Standard";
            }
        }

        public string Name = "";

        public string Description = "";

        public double Quantity = 0;

        public double Price = 0;

        public double Quality = Item.Standard; //overwrite quality if u need to, but standard by default
        
        

        


        public Item(double _Quantity)
        {
            // Name and Description will be set automatically in child classes, 
            // only need to set quantity for each stack
            Quantity = _Quantity;
        }

        public Item(double _Quantity, string _Name)
        {
            Quantity = _Quantity;
            Name = _Name;
        }

        public Item(double _Quantity, string _Name, double _Price)
        {
            Quantity = _Quantity;
            Name = _Name;
            Price = _Price;
        }

        public Item(double _Quantity, string _Name, double _Price, string _Description)
        {
            Quantity = _Quantity;
            Name = _Name;
            Description = _Description;
            Price = _Price;
        }
        public static Item ItemClone(Item duplicateFrom)
        {
            //Item cloning constructor
            Item resultItem = new Item(duplicateFrom.Quantity, duplicateFrom.Name, duplicateFrom.Price, duplicateFrom.Description);

            return resultItem;
        }

        public override string ToString()
        {
            return Quantity + " " + Name + "  [" + Price.ToString("C") + "]";
        }

        public int CompareTo(object other)
        {
            //adapted from IComparable documentation https://docs.microsoft.com/en-us/dotnet/api/system.icomparable?view=net-6.0

            if (other == null) return 1;

            Item otherItem = other as Item;

            if (otherItem != null)
            {
                return this.Name.CompareTo(otherItem.Name);
            }
            else
            {
                throw new ArgumentException("Object is not an Item");
            }
            
        }
    }
}