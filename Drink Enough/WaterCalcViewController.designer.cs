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
    [Register ("WaterCalcViewController")]
    partial class WaterCalcViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CalcButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WaterOuputLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField WeightInput { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CalcButton != null) {
                CalcButton.Dispose ();
                CalcButton = null;
            }

            if (WaterOuputLabel != null) {
                WaterOuputLabel.Dispose ();
                WaterOuputLabel = null;
            }

            if (WeightInput != null) {
                WeightInput.Dispose ();
                WeightInput = null;
            }
        }
    }
}