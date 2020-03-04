using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Drink_Enough
{
    public partial class WaterIntakeViewController : UIViewController
    {
        JsonHelper jsonHelper = new JsonHelper();
        Dictionary<string, int> jsonDict;

        public WaterIntakeViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            jsonDict = jsonHelper.jsonGetAllData();
           WaterOutputLabel.Text = jsonDict["amount"].ToString();

            PickerDataModel<int> waterModel = new PickerDataModel<int>
            {
                Items =
                {
                    new NamedValue<int>("200 ml (Glas)", 200),
                    new NamedValue<int>("500 ml", 500),
                    new NamedValue<int>("600 ml", 600),
                    new NamedValue<int>("700 ml", 700),
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

            var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) =>
            {
                WaterOutputLabel.Text = Convert.ToString(int.Parse(WaterOutputLabel.Text) - waterModel.SelectedItem.Value);
                DrinkTxtInput.ResignFirstResponder();
            });

            toolbar.SetItems(new[] { spacer, doneButton }, true);
            DrinkTxtInput.InputView = waterPicker;
            DrinkTxtInput.InputAccessoryView = toolbar;    
            
            /* waterModel.ValueChanged += (sender, args) =>
            {
               WaterOutputLabel.Text = Convert.ToString(int.Parse(WaterOutputLabel.Text) - waterModel.SelectedItem.Value);

            }; */
        }

      
       
}
    
}