using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Drink_Enough
{
    public partial class WaterIntakeViewController : UIViewController
    {
        DBHelper DBHelper = new DBHelper();
        JsonHelper jsonHelper = new JsonHelper();
        Utility utility = new Utility();
        Dictionary<string, int> jsonDict;
        private int amountDrank;
        private int amountToDrink;
        Drink drink = new Drink();

        public WaterIntakeViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Changes for HistoryVC           
            drink = utility.compareObjects(DBHelper.getLastDrink());



            jsonDict = jsonHelper.jsonGetAllData();
            WaterOutputLabel.Text = jsonDict["amount"].ToString() + " ml";
            DrinkTxtInput.SelectedTextRange = null;

            //set up PickerView to choose drinks
            PickerDataModel<int> waterModel = new PickerDataModel<int>
            {
                Items =
                {
                    new NamedValue<int>("50 ml", 50),
                    new NamedValue<int>("100 ml", 100),
                    new NamedValue<int>("150 ml", 150),
                    new NamedValue<int>("200 ml (glass)", 200),
                    new NamedValue<int>("250 ml (cup)", 250),
                    new NamedValue<int>("300 ml", 300),
                    new NamedValue<int>("350 ml", 350),
                    new NamedValue<int>("400 ml", 400),
                    new NamedValue<int>("450 ml", 450),
                    new NamedValue<int>("500 ml (small bottle)", 500),
                    new NamedValue<int>("600 ml", 600),
                    new NamedValue<int>("700 ml", 700),
                    new NamedValue<int>("800 ml", 800),
                    new NamedValue<int>("900 ml", 900),
                    new NamedValue<int>("1000 ml (bottle)", 1000),
                    new NamedValue<int>("1100 ml", 1100),
                    new NamedValue<int>("1200 ml", 1200),
                    new NamedValue<int>("1300 ml", 1300),
                    new NamedValue<int>("1400 ml", 1400),
                    new NamedValue<int>("1500 ml (big bottle)", 1500)
                }
            };

            UIPickerView waterPicker = new UIPickerView
            {
                Model = waterModel
            };

            var toolbar = new UIToolbar(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 45))
            {
                BarStyle = UIBarStyle.BlackTranslucent,
                Translucent = true
            };

            amountDrank = 0;
          
            var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);

            //what should happen if doneButton is pressed
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) =>
            {
                 amountDrank += waterModel.SelectedItem.Value;
                if (jsonDict["amount"] >= amountDrank)
                {
                amountToDrink = jsonDict["amount"] - amountDrank;
                }
                else
                {
                amountToDrink = 0;
                }

                //Changes for HistoryVC
                drink.AmountDrank = amountDrank;
                DBHelper.updateDrink(drink);

                Console.WriteLine(amountDrank.ToString());
                Console.WriteLine(amountToDrink.ToString());
                Console.WriteLine(((View.Bounds.Height - NavBar.Bounds.Height) * amountToDrink / jsonDict["amount"]).ToString());

                DrinkTxtInput.ResignFirstResponder();
                waterView.TopAnchor.ConstraintEqualTo(NavBar.BottomAnchor, (View.Bounds.Height - NavBar.Bounds.Height)
                    * amountToDrink / jsonDict["amount"]).Active = true;
                
                if (amountToDrink <= 0)
                {
                        GoalReachedOutputLabel.Text = $"I reached my goal of {jsonDict["amount"]} ml! Total amount I drank today:";
                        WaterOutputLabel.Text = (amountDrank).ToString() + " ml";
                        var alert = UIAlertController.Create("Congratulations", "You reached your daily drinking goal!", UIAlertControllerStyle.Alert);
                        alert.AddAction(UIAlertAction.Create("I am a champion", UIAlertActionStyle.Default, null));
                        PresentViewController(alert, true, null);
                }                     
                else 
                {
                  WaterOutputLabel.Text = Convert.ToString(amountToDrink) + " ml";
                }
            });
            toolbar.SetItems(new[] { spacer, doneButton }, true);
            DrinkTxtInput.InputView = waterPicker;
            DrinkTxtInput.InputAccessoryView = toolbar;            
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //reload data when view appears again
            jsonDict = jsonHelper.jsonGetAllData();

            if (amountDrank < jsonDict["amount"])
            {
                WaterOutputLabel.Text = (jsonDict["amount"] - amountDrank).ToString() + " ml";
            } else
            {
                WaterOutputLabel.Text = amountDrank.ToString() + " ml";
            }             
        }
    }    
}