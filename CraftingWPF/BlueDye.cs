using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftingSystemDemo
{
    public class BlueDye : Item
    {

        public BlueDye(double _Quantity) : base(_Quantity)
        {
            
            Name = "Blue Dye";
            Description = "This will dye your stuff blue.";
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