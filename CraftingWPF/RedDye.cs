using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftingSystemDemo
{
    public class RedDye : Item
    {

        public RedDye(double _Quantity) : base(_Quantity)
        {
            
            this.Name = "Red Dye";
            this.Description = "This will dye your stuff red.";
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