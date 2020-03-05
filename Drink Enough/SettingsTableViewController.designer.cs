// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Drink_Enough
{
    [Register ("SettingsTableViewController")]
    partial class SettingsTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel dailyWaterInTakeCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView settingsView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell waterCalculatorCell { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (dailyWaterInTakeCell != null) {
                dailyWaterInTakeCell.Dispose ();
                dailyWaterInTakeCell = null;
            }

            if (settingsView != null) {
                settingsView.Dispose ();
                settingsView = null;
            }

            if (waterCalculatorCell != null) {
                waterCalculatorCell.Dispose ();
                waterCalculatorCell = null;
            }
        }
    }
}