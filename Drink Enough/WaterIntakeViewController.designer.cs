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
    [Register ("WaterIntakeViewController")]
    partial class WaterIntakeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DrinkTxtInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GoalReachedOutputLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView waterImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WaterOutputLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DrinkTxtInput != null) {
                DrinkTxtInput.Dispose ();
                DrinkTxtInput = null;
            }

            if (GoalReachedOutputLabel != null) {
                GoalReachedOutputLabel.Dispose ();
                GoalReachedOutputLabel = null;
            }

            if (waterImageView != null) {
                waterImageView.Dispose ();
                waterImageView = null;
            }

            if (WaterOutputLabel != null) {
                WaterOutputLabel.Dispose ();
                WaterOutputLabel = null;
            }
        }
    }
}