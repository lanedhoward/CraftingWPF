﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftingSystemDemo
{
    public class Item
    {
        public string Name = "";

        public string Description = "";

        public double Quantity = 0;

        public double Price = 0;

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
            return Quantity + " " + Name + "  [" + (Price*Quantity).ToString("C") + "]";
        }

    }
}