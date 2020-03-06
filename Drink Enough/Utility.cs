using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Drink_Enough
{
    class Utility
    {
        DBHelper dBHelper = new DBHelper();

        public Drink compareObjects(Drink drink)
        {
            DateTime currentDate = DateTime.Now;
            if(drink.CreateDate == currentDate)
            {
                return drink;
            } else
            {
                Drink newDrink = new Drink
                {
                    CreateDate = DateTime.Now.Date
                };

                dBHelper.insertDrink(newDrink);
                return newDrink;
            }
        }
    }
}