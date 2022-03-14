using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftingSystemDemo
{
    public class CraftingStation : Item
    {

        public CraftingStation(double _Quantity) : base(_Quantity)
        {
            
            Name = "Crafting Station";
            Description = "You can craft here";
        }

        /*
         *so inherited constructors basically work as if it was doing
         *CraftingStation(double Quantity)
         *{
         *  base(_Quantity);
         *  //the rest ofthe code
         *}
         *
         *
         *
         */
    }
}