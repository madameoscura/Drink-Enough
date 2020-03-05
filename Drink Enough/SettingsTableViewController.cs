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
            //settingsView.Source = new TableSource();
            
    }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
           // base.RowSelected(tableView, indexPath);

            if (indexPath.Section == 0 && indexPath.Row == 0)
            {
                #region AlertDialog mit UIAlertController

                UIAlertController alertController = UIAlertController.Create("Daily water intake", "Please change your intake to a new amount (ml).", UIAlertControllerStyle.Alert);
                UITextField EditTask = null;

                alertController.AddTextField(EditTaskTxt =>
                {
                    EditTask = EditTaskTxt;
                    jsonDict = jsonHelper.jsonGetAllData();
                    EditTask.Text = jsonDict["amount"].ToString();
                });

                alertController.AddAction(UIAlertAction.Create("Update",
                    UIAlertActionStyle.Default,
                    onClick =>
                    {
                        jsonDict["amount"] = int.Parse(EditTask.Text);
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