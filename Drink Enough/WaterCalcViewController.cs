using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Drink_Enough
{
    public partial class WaterCalcViewController : UIViewController
    {

        private string calcWeightInKg;
        private string calculatedAmount;
        public static int mlToDrinkPerKg = 30;

        public WaterCalcViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
    
            //add observer to include "kg" in textfield after weight when numbers are inserted
            NSNotificationCenter.DefaultCenter.AddObserver(
            UITextField.TextDidBeginEditingNotification, (notification) => {
                WeightInput.Text = " kg";
                var indexToSet = WeightInput.Text.Length - 3;
                var positionToSet = WeightInput.GetPosition(WeightInput.BeginningOfDocument, indexToSet);
                WeightInput.SelectedTextRange = WeightInput.GetTextRange(positionToSet, positionToSet);
            });

            CalcButton.TouchUpInside += CalcButton_TouchUpInside;            
        }

        //Calculate optimal daily drinking amount when button is pressed
        private void CalcButton_TouchUpInside(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(WeightInput.Text)) && (WeightInput.Text != (" kg")))
            {
            WeightInput.ResignFirstResponder();
            calcWeightInKg = WeightInput.Text.Remove(WeightInput.Text.Length - 3, 3);
            calculatedAmount = Convert.ToString(int.Parse(calcWeightInKg) * mlToDrinkPerKg);
            WaterOuputLabel.Text = calculatedAmount + " ml";
            }
            else if (string.IsNullOrEmpty(WeightInput.Text))
            {
                UIAlertController alertController = UIAlertController.Create("Nothing to calculate", "Please insert your weight.", UIAlertControllerStyle.Alert);              
                alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
                PresentViewController(alertController, true, null);
            }
        }
    }
}