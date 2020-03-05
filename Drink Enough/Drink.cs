using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Drink_Enough
{
    class Drink
    {
        public int Weight { get; set; }
        public int DrinkingGoal { get; set; }
        public int AmountDrank { get; set; }
        public DateTime CreateDate { get; set; }

        //Standardkonstruktor
        public Drink()
        {
        }

        //überladener Konstruktor
        //wird genutzt wenn Task hinzugefügt wird
        public Drink(int weight, int goal, int amountDrank)
        {
            this.Weight = weight;
            this.DrinkingGoal = goal;
            this.AmountDrank = amountDrank;
            this.CreateDate = DateTime.Now;
        }
    }
}