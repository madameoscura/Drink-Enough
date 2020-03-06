using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Drink_Enough
{
    public partial class SettingsTableViewController : UITableViewController
    {
        JsonHelper jsonHelper = new JsonHelper();
        Dictionary<string, int> jsonDict;

        public SettingsTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
        }

        //what should happen when specific row in tableview is selected
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
           //show alertview when first cell is pressed to adjust drinking goal
            if (indexPath.Section == 0 && indexPath.Row == 0)
            {
                #region AlertDialog mit UIAlertController

                UIAlertController alertController = UIAlertController.Create("Daily water intake", "Please change your intake to a new amount (ml).", UIAlertControllerStyle.Alert);
                UITextField EditWaterIntake = null;

                alertController.AddTextField(EditWaterIntakeTxt =>
                {
                    EditWaterIntake = EditWaterIntakeTxt;
                    jsonDict = jsonHelper.jsonGetAllData();
                    EditWaterIntake.Text = jsonDict["amount"].ToString();
                });

                alertController.AddAction(UIAlertAction.Create("Update",
                    UIAlertActionStyle.Default,
                    onClick =>
                    {
                        jsonDict["amount"] = int.Parse(EditWaterIntake.Text);
                        jsonHelper.jsonWrite(jsonDict);
                        Console.WriteLine(jsonDict.Values);
                    })); 
                alertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

                PresentViewController(alertController, true, null);
                #endregion
            }

            //show alertview when third cell is pressed to adjust weight
            if (indexPath.Section == 0 && indexPath.Row == 2)
            {
                #region AlertDialog mit UIAlertController

                UIAlertController alertController = UIAlertController.Create("Change your weight", "Please enter your weight below (kg)", UIAlertControllerStyle.Alert);
                UITextField EditWeight = null;

                alertController.AddTextField(EditWeightTxt =>
                {
                    EditWeight = EditWeightTxt;
                    jsonDict = jsonHelper.jsonGetAllData();
                    EditWeight.Text = jsonDict["weight"].ToString();
                });

                alertController.AddAction(UIAlertAction.Create("Update",
                    UIAlertActionStyle.Default,
                    onClick =>
                    {
                        jsonDict["weight"] = int.Parse(EditWeight.Text);
                        jsonHelper.jsonWrite(jsonDict);
                        Console.WriteLine(jsonDict.Values);
                    }));
                alertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

                PresentViewController(alertController, true, null);
                #endregion
            }
        }
    }
}