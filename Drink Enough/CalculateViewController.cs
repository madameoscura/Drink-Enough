using Foundation;
using System;
using UIKit;

namespace Drink_Enough
{
    public partial class CalculateViewController : UIViewController
    {
        public string userWeightInKg { get; set; }
        public static int mlToDrinkPerKg = 30;
        public int finalAmountToDrink = new int();
        public string calculatedAmount { get; set; }

        public CalculateViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            calculatedAmount = Convert.ToString(int.Parse(userWeightInKg) * mlToDrinkPerKg);
            WaterTxtInput.Text = calculatedAmount + " ml";

            NSNotificationCenter.DefaultCenter.AddObserver(
            UITextField.TextDidBeginEditingNotification, (notification) => {
             var indexToSet = WaterTxtInput.Text.Length - 3;
             var positionToSet = WaterTxtInput.GetPosition(WaterTxtInput.BeginningOfDocument, indexToSet);
              WaterTxtInput.SelectedTextRange = WaterTxtInput.GetTextRange(positionToSet, positionToSet);
            });

            NSNotificationCenter.DefaultCenter.AddObserver(
           UITextField.TextFieldTextDidChangeNotification, (notification) =>
           {
               if (!string.IsNullOrEmpty(WaterTxtInput.Text) && WaterTxtInput.Text.Length > 1)
               {
                   if (WaterTxtInput.Text.Substring(WaterTxtInput.Text.Length - 2) == "ml")
                   {
                       WaterTxtInput.Text = WaterTxtInput.Text;
                   }
               }
               else
               {
                   WaterTxtInput.Text = WaterTxtInput.Text + " ml";
               }
               var indexToSet = WaterTxtInput.Text.Length - 3;
               var positionToSet = WaterTxtInput.GetPosition(WaterTxtInput.BeginningOfDocument, indexToSet);
               WaterTxtInput.SelectedTextRange = WaterTxtInput.GetTextRange(positionToSet, positionToSet);

           });
            
            DoneButton.TouchUpInside += DoneButton_TouchUpInside;
        }

        private void DoneButton_TouchUpInside(object sender, EventArgs e)
        {
          //  finalAmountToDrink = int.Parse(WaterTxtInput.Text);
            finalAmountToDrink = int.Parse(WaterTxtInput.Text.Remove(WaterTxtInput.Text.Length - 3, 3));
            Console.WriteLine(finalAmountToDrink);
        }
    }
}