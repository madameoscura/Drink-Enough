using Foundation;
using System;
using UIKit;

namespace Drink_Enough
{
    public partial class WeightViewController : UIViewController
    {
       
        public WeightViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NSNotificationCenter.DefaultCenter.AddObserver(
            UITextField.TextFieldTextDidChangeNotification, (notification) =>
            { if (!string.IsNullOrEmpty(WeightTxtInput.Text) && WeightTxtInput.Text.Length > 1)
                { 
                 if (WeightTxtInput.Text.Substring(WeightTxtInput.Text.Length - 2) == "kg")
                 {
                WeightTxtInput.Text = WeightTxtInput.Text;
                 }
                }
                else
                {
                WeightTxtInput.Text = WeightTxtInput.Text + " kg";
                }
                var indexToSet = WeightTxtInput.Text.Length - 3;
                var positionToSet = WeightTxtInput.GetPosition(WeightTxtInput.BeginningOfDocument, indexToSet);
                WeightTxtInput.SelectedTextRange = WeightTxtInput.GetTextRange(positionToSet, positionToSet);
            
            });
        }

        
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var Controller = segue.DestinationViewController
                as CalculateViewController;

            if (Controller != null)
            { 
                Controller.userWeightInKg = WeightTxtInput.Text.Remove(WeightTxtInput.Text.Length - 3, 3);

               
            }
        }
    }
}